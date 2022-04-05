

    function Decide(option) {
        var temp = "";
    document.getElementById('lblRate').innerText = "";
    if (option == 1) {
        document.getElementById('Rating1').className = "Filled";
    document.getElementById('Rating2').className = "Empty";
    document.getElementById('Rating3').className = "Empty";
    document.getElementById('Rating4').className = "Empty";
    document.getElementById('Rating5').className = "Empty";
    temp = "1-Poor";
        }
    if (option == 2) {
        document.getElementById('Rating1').className = "Filled";
    document.getElementById('Rating2').className = "Filled";
    document.getElementById('Rating3').className = "Empty";
    document.getElementById('Rating4').className = "Empty";
    document.getElementById('Rating5').className = "Empty";
    temp = "2-Ok";

        }
    if (option == 3) {
        document.getElementById('Rating1').className = "Filled";
    document.getElementById('Rating2').className = "Filled";
    document.getElementById('Rating3').className = "Filled";
    document.getElementById('Rating4').className = "Empty";
    document.getElementById('Rating5').className = "Empty";
    temp = "3-Fair";
        }
    if (option == 4) {
        document.getElementById('Rating1').className = "Filled";
    document.getElementById('Rating2').className = "Filled";
    document.getElementById('Rating3').className = "Filled";
    document.getElementById('Rating4').className = "Filled";
    document.getElementById('Rating5').className = "Empty";
    temp = "4-Good";
        }
    if (option == 5) {
        document.getElementById('Rating1').className = "Filled";
    document.getElementById('Rating2').className = "Filled";
    document.getElementById('Rating3').className = "Filled";
    document.getElementById('Rating4').className = "Filled";
    document.getElementById('Rating5').className = "Filled";
    temp = "5-Nice";
        }
    document.getElementById('lblRate').innerText = temp;
    return false;
    }

