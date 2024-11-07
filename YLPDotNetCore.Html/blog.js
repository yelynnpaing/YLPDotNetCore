const tblBlog = "blogs";

// createBlog();
readBlog();
// updateBlog("a295027a-d5a6-4fa1-bb2c-66cb46d594e5", "test", "test", "test");
deleteBlog("a295027a-d5a6-4fa1-bb2c-66cb46d594e5");

function readBlog(){
    const blogs = localStorage.getItem(tblBlog);
    console.log(blogs);
}

function createBlog(){
    const blogs = localStorage.getItem(tblBlog);
    // console.log(blogs);
    
    let lst = [];
    if(blogs !== null){
        lst = JSON.parse(blogs);
    }

    const requestModel = {
        id: uuidv4(),
        title: "test title l",
        author: "test author2 l",
        content: "test content l"
    };

    lst.push(requestModel);
    let blogJson = JSON.stringify(lst);
    localStorage.setItem("blogs", blogJson);
};

function updateBlog(id, title, author, content){
    const blogs = localStorage.getItem(tblBlog);

    let lst = [];
    if(blogs !== null){
        lst = JSON.parse(blogs);
    }

    let items = lst.filter(x => x.id === id);
    // console.log(items);
    if(items.length == 0){
        console.log("no data found.");
        return;
    }

    let item = items[0];
    item.id = id;
    item.title = title;
    item.author = author;
    item.content = content;

    let index = lst.findIndex(x => x.id === id);
    lst[index] = item;

    const jsonBlog = JSON.stringify(lst);
    localStorage.setItem("blogs", jsonBlog);    
}

function deleteBlog(id){
    const blogs = localStorage.getItem(tblBlog);
    let lst = [];
    if(blogs !== null){
        lst = JSON.parse(blogs);
    }

    let items = lst.filter(x => x.id === id);
    if(items.length === 0){
        console.log("no data found.");
        return;
    }

    lst = lst.filter(x => x.id !== id);
    const jsonBlog = JSON.stringify(lst);
    localStorage.setItem("blogs", jsonBlog);
    readBlog();
}

function uuidv4() {
    return "10000000-1000-4000-8000-100000000000".replace(/[018]/g, c =>
      (+c ^ crypto.getRandomValues(new Uint8Array(1))[0] & 15 >> +c / 4).toString(16)
    );
  }
  
