// Seleciona os elementos
const abrirBtn = document.getElementById("abrirBtn");
const fecharBtn = document.getElementById("fecharBtn");
const overlay = document.getElementById("popupOverlay");

// Abre o popup
abrirBtn.addEventListener("click", () => {
  overlay.style.display = "flex";
});

// Fecha o popup
fecharBtn.addEventListener("click", () => {
  overlay.style.display = "none";
});
