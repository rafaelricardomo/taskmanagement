# Gerenciamento de tarefas

O sistema de gerenciamento de tarefas é uma **API** que possibilita organizar e monitorar suas tarefas diárias dentro de um projeto.

1. **Listagem de Projetos** - listar todos os projetos do usuário
2. **Visualização de Tarefas** - visualizar todas as tarefas de um projeto específico
3. **Criação de Projetos** - criar um novo projeto
4. **Criação de Tarefas** - adicionar uma nova tarefa a um projeto
5. **Atualização de Tarefas** - atualizar o status ou detalhes de uma tarefa
6. **Remoção de Tarefas** - remover uma tarefa de um projeto

# Regras de negócio

1. Aprimorar o entendimento sobre estrutura de usuários, perfis e permissionamento.
2. Detalhar vínculo do usuário com as tarefas do projeto.


# Débitos técnicos

1. Melhoria nos pontos de validações e padrão de retorno (ProblemDetails) dos endpoints das apis 
2. Criação de script completo para banco de dados
3. Avaliação do modelo de dados atual

# Instruções para Docker

1. Acesse a pasta "taskmanagement" do projeto via terminal com comando
**cd taskmanagement**

2. Execute o comando para construir imagem docker do projeto
**docker build -f taskmanagement.api/Dockerfile -t taskmanagementapi . **

3. Execute o comando para rodar a api no docker
**docker run -p 8081:8081 -p 8080:8080 --name taskmanagementapi1  -d taskmanagementapi**

4. Acesso endereço no seu navegador
**http://localhost:8080/swagger**

Obs. A conexão com banco de dados somente será estabelecida estando na mesma rede da sua imagem sqlserver local 
