// Get references to HTML elements
const holdingsTableBody = document.querySelector('#holdingsTable tbody');
const transactionForm = document.querySelector('#transactionForm');

// Define an array to store holdings data (for demonstration purposes)
let holdingsData = [
  { bondName: 'Bond A', quantity: 100, currentPrice: 50.5, conversionRatio: 0.8 },
  { bondName: 'Bond B', quantity: 50, currentPrice: 75.2, conversionRatio: 1.2 },
  // Add more sample data here
];

// Function to render holdings table
function renderHoldingsTable() {
  holdingsTableBody.innerHTML = '';

  holdingsData.forEach(holding => {
    const row = document.createElement('tr');
    row.innerHTML = `
      <td>${holding.bondName}</td>
      <td>${holding.quantity}</td>
      <td>${holding.currentPrice}</td>
      <td>${holding.conversionRatio}</td>
    `;
    holdingsTableBody.appendChild(row);
  });
}

// Event listener for transaction form submission
transactionForm.addEventListener('submit', event => {
  event.preventDefault();

  const bondName = document.querySelector('#bondName').value;
  const quantity = parseInt(document.querySelector('#quantity').value);
  const price = parseFloat(document.querySelector('#price').value);
  const transactionType = document.querySelector('#transactionType').value;

  // Perform the necessary logic based on the transaction details
  if (transactionType === 'buy') {
    // Add the bond to the holdingsData array
    holdingsData.push({
      bondName: bondName,
      quantity: quantity,
      currentPrice: price,
      conversionRatio: 0, // Replace with actual conversion ratio calculation
    });
  } else if (transactionType === 'sell') {
    // Implement the sell logic
    // Remove the bond from the holdingsData array
  }

  // Clear the form inputs
  transactionForm.reset();

  // Re-render the holdings table
  renderHoldingsTable();
});

// Initial rendering of the holdings table
renderHoldingsTable();
