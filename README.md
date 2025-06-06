# PowerNow 

## 📌 Visão Geral
PowerNow é um sistema console desenvolvido em **C#**, com foco em registrar, listar e gerar relatórios sobre falhas elétricas ocorridas por desastres naturais ou causas cibernéticas. Ele auxilia na resposta emergencial e tomada de decisões por parte de operadores e autoridades locais.

---

## 🚀 Funcionalidades
- 🔐 **Login Seguro** 
- 📝 **Registro de Falhas** 
- 📋 **Listagem de Falhas Ativas**
- 📊 **Estatísticas da Sessão** 
- 📁 **Geração de Relatórios** em `.txt`
- 🧾 **Registro de Logs** automáticos

---

## 📚 Tecnologias Utilizadas
- Linguagem: **C#**
- Plataforma: **.NET 6.0+**
- Execução: **Aplicação Console**
- Armazenamento: Memória + Arquivo `.txt` + `eventos.log`
- IDE: Visual Studio / VS Code

---

## 🛡️ Regras de Negócio
- Só permite acesso após login válido
- Dados inválidos são tratados com `try-catch`
- Impacto deve ser classificado como **baixo**, **médio** ou **alto**
- Relatórios e logs são atualizados automaticamente após ações
- Sistema não persiste os dados entre execuções
