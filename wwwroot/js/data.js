const connection = new signalR.HubConnectionBuilder().withUrl("/myhub").build();

connection.on("ReceiveUpdatedData", function (data) {
    const parsedData = JSON.parse(data);

    const dataContainer = document.getElementById("data");
    dataContainer.textContent = data;
    console.log(data);


    /*dataContainer.innerHTML = "";
    const ul = document.createElement("ul");
    parsedData.forEach((banksExchangeRate, index) => {
        const li = document.createElement("li");

        li.innerHTML = `
            <h2>Banks ${index + 1}</h2>
            <ol>
                ${banksExchangeRate.CurrencyExchangeRates.map(rate =>
            `<li>(${currencyExchangeRate.CurrencyCode}) ${currencyExchangeRate.CurrencyName} -> buying at ${currencyExchangeRate.CurrencyBuying} ETB and selling at ${currencyExchangeRate.CurrencySelling}</li>`
        ).join('')}
            </ol>
        `;
        ul.appendChild(li);
    })

    dataContainer.appendChild(ul);*/


    //document.getElementById("data").innerHTML = `${parsedData}`;
});
connection.start().then(() => {
    fetch("/ExchangeRate/Index")
        .then(response => {
            if (!response.ok) {
                console.error("failed to send data");
            }
        })
        .catch(err => console.error(err));
}).catch(err => console.error(error));