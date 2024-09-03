const container = document.getElementById("data");
const connection = new signalR.HubConnectionBuilder().withUrl("/myhub").build();
connection.on("ReceiveUpdatedData", function (data) {
    RenderUI(data);
});
connection.start();
function RenderUI(data)
{
    const parsedData = JSON.parse(data);
    container.innerHTML = ``;

    parsedData.forEach((bank) => {
        const table = document.createElement('table');
        table.className = "table exhange_rate w-100 text-sm table-striped rounded my-3 p-2";

        const thead = document.createElement('thead');
        thead.className = "rounded my-2 border";

        const titleRow = document.createElement('tr');
        titleRow.className = "fs-15";
        titleRow.style.color = "#000";

        const titleHeader = document.createElement('th');
        titleHeader.scope = "col";
        titleHeader.colSpan = "10";
        titleHeader.className = "text-capitalize text-left exhange_rate_header";
        titleHeader.style.paddingLeft = "20px";

        const titleDiv = document.createElement('div');
        titleDiv.className = "title_and_time d-flex";
        titleDiv.style.justifyContent = "space-between";
        titleDiv.style.gap = "10px";

        const titleContentDiv = document.createElement('div');
        titleContentDiv.className = "d-flex";
        titleContentDiv.style.gap = "5px";

        const bankTitle = document.createElement('h3');
        bankTitle.className = "m-0 d-flex";
        bankTitle.style.alignItems = "center";
        bankTitle.style.fontSize = "20px";
        bankTitle.style.color = "#fff";
        bankTitle.style.lineHeight = "23px";
        bankTitle.style.fontWeight = "700";
        bankTitle.innerHTML = `<p class="text-dark" >${bank.BankName} Exchange Rate</p>`; // Update with actual bank link if needed

        titleContentDiv.appendChild(bankTitle);
        titleDiv.appendChild(titleContentDiv);

        titleHeader.appendChild(titleDiv);
        titleRow.appendChild(titleHeader);
        thead.appendChild(titleRow);

        const headerRow = document.createElement('tr');
        headerRow.style.backgroundColor = "#D3B683";
        headerRow.style.color = "#000";

        const headers = ["Code", "Buying", "Selling"];
        headers.forEach(headerText => {
            const th = document.createElement('th');
            th.scope = "col";
            th.className = "t_head text-capitalize";
            th.style.fontSize = "16px";
            th.style.textAlign = "left";
            th.style.paddingLeft = "60px";
            th.textContent = headerText;
            headerRow.appendChild(th);
        });

        thead.appendChild(headerRow);
        table.appendChild(thead);

        const tbody = document.createElement('tbody');
        tbody.className = "border";

        bank.CurrencyExchangeRates.forEach(item => {
            const row = document.createElement('tr');

            const codeCell = document.createElement('td');
            codeCell.style.textAlign = "left";
            codeCell.style.paddingLeft = "30px";
            const codeDiv = document.createElement('div');

            const currencyCode = document.createElement('p');
            currencyCode.textContent = item.CurrencyCode;

            codeDiv.appendChild(currencyCode);
            codeCell.appendChild(codeDiv);

            const buyingCell = document.createElement('td');
            buyingCell.style.textAlign = "left";
            buyingCell.style.color = "#6FC276";
            buyingCell.style.fontWeight = "bold";
            buyingCell.textContent = item.CurrencyBuying;

            const sellingCell = document.createElement('td');
            sellingCell.style.textAlign = "left";
            sellingCell.style.color = "#FF007F";
            sellingCell.style.fontWeight = "bold";
            sellingCell.textContent = item.CurrencySelling;

            row.appendChild(codeCell);
            row.appendChild(buyingCell);
            row.appendChild(sellingCell);

            tbody.appendChild(row);
        });

        table.appendChild(tbody);
        container.appendChild(table);
    });

    console.log(parsedData);
}