async function falarComJarbas() {
  const pergunta = document.getElementById("question").value;
  const respostaEl = document.getElementById("resposta");

  if (!pergunta.trim()) {
    respostaEl.innerText = "Escreve algo aí, parceiro!";
    return;
  }

  respostaEl.innerText = "Jarbas está pensando...";

  // URL do backend dentro do Docker
  const apiUrl = "http://localhost:8080/chat";

  try {
    const res = await fetch(apiUrl, {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(pergunta) // manda só a string
    });

    if (!res.ok) throw new Error("Erro na resposta da API");

    const data = await res.json();
    respostaEl.innerHTML = marked.parse(data.response); // response, não answer
  } catch (err) {
    console.error("Erro ao falar com o Jarbas:", err);
    respostaEl.innerText = "Deu ruim... o Jarbas não respondeu 😢";
  }
}