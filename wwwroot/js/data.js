const connection = new signalR.HubConnectionBuilder().withUrl("/myhub").build();

connection.on("ReceiveUpdatedData", function (data) {
    const container = document.getElementById("data")

    const parsedData = JSON.parse(data);
    container.textContent = "";


    parsedData.forEach((bank, index) => {
        const bankTitle = document.createElement('h3');
        bankTitle.textContent = `${bank.BankName}`;

        const bankContainer = document.createElement('div');
        const listElement = document.createElement('ul');
        const orderedList = document.createElement('ol');

        bank.CurrencyExchangeRates.forEach(item => {
            const itemElement = document.createElement('li');
            itemElement.textContent = `(${item.CurrencyCode}) ${item.CurrencyName} -> buying at ${item.CurrencyBuying} and selling at ${item.CurrencySelling}`;
            orderedList.appendChild(itemElement);
        });

        listElement.appendChild(orderedList);
        bankContainer.appendChild(bankTitle);
        bankContainer.appendChild(listElement);
        container.appendChild(bankContainer);
    });

    console.log(parsedData);
});
connection.start();