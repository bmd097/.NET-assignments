{

    let page = 2;
    let limit = 3;
    let prevBtn = document.getElementById("prevBtn");
    let nextBtn = document.getElementById("nextBtn");
    let mainContent = document.querySelector(".main-content");

    let renderContent = (data) => {
        let res = "";
        data.forEach(e => {
            res += `
        <div class="row">
            <div class="cell"><p>&nbsp;&nbsp; ${e.ArticleId}</p></div>
            <div class="cell"><p>${e.Title}</p></div>
            <div class="cell"><p>${e.Content}</p></div>
            <div class="cell"><p>${e.PublishedDate}</p></div>
            <div class="cell"><p>${e.LastModifiedDate}<p></div>
            <div class="cell"><p>${e.Author}<p></div>
            <div class="cell"><p>${e.Category}</p></div>
            <div class="cell">
                <button>Delete</button>
            </div>
        </div>
        `;
        });
        
        mainContent.innerHTML = res;
    }

    let fetchContent = async () => {
        fetch("/api/WordVoyeger", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({
                page: page,
                limit: limit
            })
        }).then(res => res.json())
            .then(data => renderContent(data))
            .catch(err => console.log(err));
    };

    fetchContent();


    nextBtn.addEventListener("click", () => {
        page = page + 1;
        fetchContent();
    });

    prevBtn.addEventListener("click", () => {
        if (page > 1) {
            page = page - 1;
            fetchContent();
        }
    });

}