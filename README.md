# codes
---

Atualizador Universal de Scripts

Como usar:
Coloque os scripts que deseja atualizar/criar na seção indicada do arquivo (na área "scripts/arquivos que serão adicionados ou atualizados") e execute o script principal. Ele gerenciará backups, atualizações e versões automaticamente.

Manuseio:
Você pode modificar e personalizar este script, mas pedimos que mantenha os créditos:

Autor: RetrKill0

Revisado: Copilot


Testado em:

Servidores Debian 10 e CentOS 6

Ambientes Desktop (Ubuntu)


Funcionalidades principais:

1. Atualização de Scripts:
Verifica a versão atual de cada script no diretório configurado e a atualiza caso necessário, preservando backups automáticos.


2. Criação de Scripts:
Cria scripts inexistentes com o conteúdo e versão especificados.


3. Gerenciamento de Cron Jobs:
Valida e cria arquivos de cron associados aos scripts.

Pré-requisitos:

Atribua o diretório correto dos scripts na variável SCRIPT_DIR.

O script precisa de permissões para gravar no diretório de logs /var/log/ e gerenciar cron jobs em /etc/cron.d/.

---
