window.addEventListener("beforeunload", function (event) {
    sessionStorage.removeItem("userEmail");
});
