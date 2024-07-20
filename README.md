<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
</head>
<body>
<h1>API RESTful com Entity Framework</h1>
<h2>Descrição</h2>
<p>Esta é uma API RESTful desenvolvida para se comunicar com uma base de dados local SQL Server. A API foi construída utilizando o Entity Framework para facilitar o mapeamento objeto-relacional (ORM). Inclui tratamento de erros com blocos try-catch, otimizações nas consultas GET e retorno adequado de status e informações nos endpoints POST.</p>
<h2>Tecnologias Utilizadas</h2>
<ul>
    <li>.NET Core</li>
    <li>Entity Framework</li>
    <li>SQL Server</li>
</ul>
<h2>Funcionalidades</h2>
<ul>
    <li>CRUD completo (Create, Read, Update, Delete) para as entidades.</li>
    <li>Otimização nas consultas GET para melhorar a performance.</li>
    <li>Tratamento de erros robusto com blocos try-catch.</li>
    <li>Endpoints POST retornam status 201 (Created) juntamente com informações do objeto criado para fácil acesso.</li>
</ul>
<h2>Requisitos</h2>
<ul>
    <li>.NET Core SDK</li>
    <li>SQL Server</li>
</ul>
<h2>Configuração do Ambiente</h2>
<ol>
    <li><strong>Clone o repositório:</strong>
        <pre><code>git clone https://github.com/seu-usuario/sua-api.git
cd sua-api
</code></pre>
    </li>
    <li><strong>Configure a conexão com o banco de dados:</strong>
        <p>No arquivo <code>appsettings.json</code>, atualize a string de conexão para apontar para o seu servidor SQL Server local:</p>
        <pre><code>{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=SuaBaseDeDados;Trusted_Connection=True;"
  }
}
</code></pre>
    </li>
    <li><strong>Execute as migrações do Entity Framework para criar o banco de dados:</strong>
        <pre><code>dotnet ef database update
</code></pre>
    </li>
    <li><strong>Execute a aplicação:</strong>
        <pre><code>dotnet run
</code></pre>
    </li>
</ol>
<h2>Endpoints</h2>
<ul>
    <li><strong>GET /entidades</strong>: Retorna uma lista de todas as entidades.</li>
    <li><strong>GET /entidades/{id}</strong>: Retorna uma entidade específica pelo ID.</li>
    <li><strong>POST /entidades</strong>: Cria uma nova entidade. Retorna status 201 (Created) com informações do objeto criado.</li>
    <li><strong>PUT /entidades/{id}</strong>: Atualiza uma entidade existente pelo ID.</li>
    <li><strong>DELETE /entidades/{id}</strong>: Remove uma entidade existente pelo ID.</li>
</ul>
<h2>Tratamento de Erros</h2>
<p>Todos os endpoints são protegidos com blocos try-catch para garantir que erros sejam capturados e respostas adequadas sejam enviadas ao cliente.</p>
<h2>Contribuição</h2>
<ol>
    <li>Fork o projeto</li>
    <li>Crie sua feature branch (<code>git checkout -b feature/AmazingFeature</code>)</li>
    <li>Commit suas mudanças (<code>git commit -m 'Add some AmazingFeature'</code>)</li>
    <li>Push para a branch (<code>git push origin feature/AmazingFeature</code>)</li>
    <li>Abra um Pull Request</li>
</ol>
<h2>Licença</h2>
<p>Distribuído sob a licença MIT. Veja <code>LICENSE</code> para mais informações.</p>
</body>
</html>
