export const fetchCustomers = async (searchOptions) => {

    const urlParams = {
        search: searchOptions.name,
        filter_by_company_name: searchOptions.companyName
    };

    var url = new URL("https://localhost:5001/api/customer");
    url.search = new URLSearchParams(urlParams).toString();

    return await fetch(url)
        .then(response => response.json())
        .catch(() => alert("Could not reach server, try again later"));
};