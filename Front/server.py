#!/usr/bin/env python3
import http.server
import socketserver
import os

PORT = 5000

class CustomHTTPRequestHandler(http.server.SimpleHTTPRequestHandler):
    def end_headers(self):
        # Adicionar headers para evitar cache
        self.send_header('Cache-Control', 'no-cache, no-store, must-revalidate')
        self.send_header('Pragma', 'no-cache')
        self.send_header('Expires', '0')
        super().end_headers()
    
    def guess_type(self, path):
        """Adicionar tipos MIME personalizados se necessário"""
        mimetype = super().guess_type(path)
        if str(path).endswith('.js'):
            return 'application/javascript'
        return mimetype

def main():
    # Certificar que estamos no diretório correto
    os.chdir(os.path.dirname(os.path.abspath(__file__)))
    
    with socketserver.TCPServer(("0.0.0.0", PORT), CustomHTTPRequestHandler) as httpd:
        print(f"Servidor rodando na porta {PORT}")
        print(f"Acesse: http://localhost:{PORT}")
        print("Pressione Ctrl+C para parar o servidor")
        
        try:
            httpd.serve_forever()
        except KeyboardInterrupt:
            print("\nServidor parado.")
            httpd.shutdown()

if __name__ == "__main__":
    main()