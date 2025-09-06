// Sistema de Navegação
document.addEventListener('DOMContentLoaded', function() {
    // Elementos do DOM
    const menuLinks = document.querySelectorAll('.menu-link');
    const contentSections = document.querySelectorAll('.content-section');
    const pageTitle = document.getElementById('page-title');

    // Mapeamento de seções para títulos
    const sectionTitles = {
        'dashboard': 'Dashboard',
        'clientes': 'Cadastro de Clientes',
        'equipamentos': 'Cadastro de Equipamentos',
        'ordens-servico': 'Ordens de Serviço',
        'servicos': 'Serviços',
        'orcamentos': 'Orçamentos',
        'historico': 'Histórico de Reparos',
        'relatorios': 'Relatórios e Análises',
        'agenda': 'Agenda de Técnicos',
        'checkin-checkout': 'Check-in/Check-out',
        'comunicacao': 'Comunicação',
        'assinatura': 'Assinatura Digital',
        'anexos': 'Fotos e Anexos',
        'garantia': 'Controle de Garantia',
        'usuarios': 'Gestão de Usuários',
        'backup': 'Backup e Segurança',
        'integracao': 'Integração ERP/Contábil'
    };

    // Função para alternar seções
    function showSection(sectionId) {
        // Esconder todas as seções
        contentSections.forEach(section => {
            section.classList.remove('active');
        });

        // Remover classe active de todos os links
        menuLinks.forEach(link => {
            link.classList.remove('active');
        });

        // Mostrar seção selecionada
        const targetSection = document.getElementById(sectionId);
        if (targetSection) {
            targetSection.classList.add('active');
        }

        // Ativar link correspondente
        const activeLink = document.querySelector(`[data-section="${sectionId}"]`);
        if (activeLink) {
            activeLink.classList.add('active');
        }

        // Atualizar título da página
        if (sectionTitles[sectionId]) {
            pageTitle.textContent = sectionTitles[sectionId];
        }

        // Atualizar URL sem recarregar a página
        history.pushState(null, null, `#${sectionId}`);
    }

    // Event listeners para os links do menu
    menuLinks.forEach(link => {
        link.addEventListener('click', function(e) {
            e.preventDefault();
            const sectionId = this.getAttribute('data-section');
            showSection(sectionId);
        });
    });

    // Gerenciar navegação do histórico do browser
    window.addEventListener('popstate', function() {
        const hash = window.location.hash.substring(1);
        if (hash && document.getElementById(hash)) {
            showSection(hash);
        } else {
            showSection('dashboard');
        }
    });

    // Verificar hash na URL ao carregar a página
    window.addEventListener('load', function() {
        const hash = window.location.hash.substring(1);
        if (hash && document.getElementById(hash)) {
            showSection(hash);
        }
    });

    // Formulário de Clientes
    const clientForm = document.querySelector('.client-form');
    if (clientForm) {
        clientForm.addEventListener('submit', function(e) {
            e.preventDefault();
            
            // Aqui você conectaria com sua API
            const formData = new FormData(this);
            const clientData = Object.fromEntries(formData);
            
            console.log('Dados do cliente:', clientData);
            
            // Simular salvamento
            alert('Cliente salvo com sucesso! (Conecte com sua API)');
            this.reset();
        });
    }

    // Formulário de Equipamentos
    const equipmentForm = document.querySelector('.equipment-form');
    if (equipmentForm) {
        equipmentForm.addEventListener('submit', function(e) {
            e.preventDefault();
            
            // Aqui você conectaria com sua API
            const formData = new FormData(this);
            const equipmentData = Object.fromEntries(formData);
            
            console.log('Dados do equipamento:', equipmentData);
            
            // Simular salvamento
            alert('Equipamento cadastrado com sucesso! (Conecte com sua API)');
            this.reset();
        });
    }

    // Botões de limpar formulários
    const clearButtons = document.querySelectorAll('.btn-secondary');
    clearButtons.forEach(button => {
        if (button.textContent.trim() === 'Limpar') {
            button.addEventListener('click', function() {
                const form = this.closest('form');
                if (form) {
                    form.reset();
                }
            });
        }
    });

    // Botão de logout
    const logoutBtn = document.querySelector('.logout-btn');
    if (logoutBtn) {
        logoutBtn.addEventListener('click', function() {
            if (confirm('Tem certeza que deseja sair?')) {
                // Aqui você implementaria a lógica de logout
                alert('Logout realizado! (Implementar lógica de logout)');
            }
        });
    }

    // Upload de logo (simulado)
    const logoPlaceholder = document.querySelector('.logo-placeholder');
    if (logoPlaceholder) {
        logoPlaceholder.addEventListener('click', function() {
            const input = document.createElement('input');
            input.type = 'file';
            input.accept = 'image/*';
            
            input.addEventListener('change', function(e) {
                const file = e.target.files[0];
                if (file) {
                    const reader = new FileReader();
                    reader.onload = function(e) {
                        const img = logoPlaceholder.querySelector('img');
                        const text = logoPlaceholder.querySelector('.logo-text');
                        
                        img.src = e.target.result;
                        img.style.display = 'block';
                        text.style.display = 'none';
                    };
                    reader.readAsDataURL(file);
                }
            });
            
            input.click();
        });
    }

    // Filtros e busca nas tabelas (simulado)
    const searchInputs = document.querySelectorAll('.search-input');
    searchInputs.forEach(input => {
        input.addEventListener('input', function() {
            const searchTerm = this.value.toLowerCase();
            console.log('Buscar por:', searchTerm);
            // Aqui você implementaria a busca real conectando com sua API
        });
    });

    const filterSelects = document.querySelectorAll('.filter-select');
    filterSelects.forEach(select => {
        select.addEventListener('change', function() {
            const filterValue = this.value;
            console.log('Filtrar por:', filterValue);
            // Aqui você implementaria o filtro real conectando com sua API
        });
    });

    // Responsividade - Toggle do menu lateral em dispositivos móveis
    function createMobileToggle() {
        if (window.innerWidth <= 768) {
            let toggleButton = document.querySelector('.mobile-toggle');
            
            if (!toggleButton) {
                toggleButton = document.createElement('button');
                toggleButton.className = 'mobile-toggle';
                toggleButton.innerHTML = '☰';
                toggleButton.style.cssText = `
                    position: fixed;
                    top: 20px;
                    left: 20px;
                    z-index: 1001;
                    background: #dc3545;
                    color: white;
                    border: none;
                    padding: 10px;
                    border-radius: 4px;
                    font-size: 18px;
                    cursor: pointer;
                `;
                
                document.body.appendChild(toggleButton);
                
                toggleButton.addEventListener('click', function() {
                    const sidebar = document.querySelector('.sidebar');
                    sidebar.classList.toggle('open');
                });
            }
        } else {
            const toggleButton = document.querySelector('.mobile-toggle');
            if (toggleButton) {
                toggleButton.remove();
            }
        }
    }

    // Verificar responsividade na carga e redimensionamento
    createMobileToggle();
    window.addEventListener('resize', createMobileToggle);

    // Fechar menu lateral quando clicar fora (mobile)
    document.addEventListener('click', function(e) {
        const sidebar = document.querySelector('.sidebar');
        const toggleButton = document.querySelector('.mobile-toggle');
        
        if (window.innerWidth <= 768 && sidebar.classList.contains('open')) {
            if (!sidebar.contains(e.target) && e.target !== toggleButton) {
                sidebar.classList.remove('open');
            }
        }
    });

    console.log('Sistema de Assistência Técnica carregado com sucesso!');
    console.log('Pronto para conectar com sua API backend.');
});

// Função utilitária para formatar CPF/CNPJ
function formatCpfCnpj(value) {
    // Remove tudo que não é dígito
    value = value.replace(/\D/g, '');
    
    if (value.length <= 11) {
        // CPF
        value = value.replace(/(\d{3})(\d)/, '$1.$2');
        value = value.replace(/(\d{3})(\d)/, '$1.$2');
        value = value.replace(/(\d{3})(\d{1,2})$/, '$1-$2');
    } else {
        // CNPJ
        value = value.replace(/^(\d{2})(\d)/, '$1.$2');
        value = value.replace(/^(\d{2})\.(\d{3})(\d)/, '$1.$2.$3');
        value = value.replace(/\.(\d{3})(\d)/, '.$1/$2');
        value = value.replace(/(\d{4})(\d)/, '$1-$2');
    }
    
    return value;
}

// Função utilitária para formatar telefone
function formatPhone(value) {
    value = value.replace(/\D/g, '');
    
    if (value.length <= 10) {
        value = value.replace(/^(\d{2})(\d{4})(\d{0,4}).*/, '($1) $2-$3');
    } else {
        value = value.replace(/^(\d{2})(\d{5})(\d{0,4}).*/, '($1) $2-$3');
    }
    
    return value;
}

// Aplicar formatação automática nos campos
document.addEventListener('DOMContentLoaded', function() {
    // Formatação de CPF/CNPJ
    const cpfInputs = document.querySelectorAll('input[name="cpf"]');
    cpfInputs.forEach(input => {
        input.addEventListener('input', function() {
            this.value = formatCpfCnpj(this.value);
        });
    });

    // Formatação de telefone
    const phoneInputs = document.querySelectorAll('input[type="tel"]');
    phoneInputs.forEach(input => {
        input.addEventListener('input', function() {
            this.value = formatPhone(this.value);
        });
    });
});