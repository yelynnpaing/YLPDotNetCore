const tblBlog = "blogs";
let blogId = null;

//JQuery
getBlogTable();

// JS
// createBlog("JJ", "aa", "CC");
readBlogs();
// updateBlog("a295027a-d5a6-4fa1-bb2c-66cb46d594e5", "test", "test", "test");
// deleteBlog("a295027a-d5a6-4fa1-bb2c-66cb46d594e5");

function readBlogs(){
    const blogs = localStorage.getItem(tblBlog);
    console.log(blogs);
}

function editBlog(id){
    let lst = getBlogs();
    let items = lst.filter(x => x.id === id);
    if(items.length === 0){
        console.log("no data found.");
        errorMessage("No data found.");
    }
    let item = items[0];
    blogId = item.id;
    $('#txtTitle').val(item.title);
    $('#txtAuthor').val(item.author);
    $('#txtContent').val(item.content);
}

function createBlog(title, author, content){
    let lst = getBlogs();

    const requestModel = {
        id: uuidv4(),
        title: title,
        author: author,
        content: content
    };

    lst.push(requestModel);
    let blogJson = JSON.stringify(lst);
    localStorage.setItem("blogs", blogJson);
};

function updateBlog(id, title, author, content){
    let lst = getBlogs();

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
    let result = confirm("Are you sure want to delete.");
    if(!result) return;

    let lst = getBlogs();
    let items = lst.filter(x => x.id === id);
    if(items.length === 0){
        console.log("no data found.");
        return;
    }

    lst = lst.filter(x => x.id !== id);
    const jsonBlog = JSON.stringify(lst);
    localStorage.setItem("blogs", jsonBlog);
    successMessage("Deleting success.");
    readBlogs();
    getBlogTable();
}

function uuidv4() {
    return "10000000-1000-4000-8000-100000000000".replace(/[018]/g, c =>
      (+c ^ crypto.getRandomValues(new Uint8Array(1))[0] & 15 >> +c / 4).toString(16)
    );
}

function getBlogs(){
    const blogs = localStorage.getItem(tblBlog);
    let lst = [];
    if(blogs !== null){
        lst = JSON.parse(blogs);
    }

    return lst;
}

//JQuery 
$('#saveBtn').click(function (){
    console.log("click");
    const title = $('#txtTitle').val();
    const author = $('#txtAuthor').val();
    const content = $('#txtContent').val();

    if(blogId === null && title != '' && author != '' && content != ''){
        createBlog(title, author, content);
        successMessage("Saving success.");
        clearControls();
    }
    else if(blogId !== null & title != '' && author != '' && content != ''){
        updateBlog(blogId, title, author, content);
        successMessage("Saving success.");
        clearControls();
    }
    else{
        successMessage("All fields are required.");
    }
    
    blogId = null;
    getBlogTable();
});

function successMessage(message){
    alert(message);
}

function errorMessage(message){
    alert(message);
}

function clearControls(){
    $('#txtTitle').val('');
    $('#txtAuthor').val('');
    $('#txtContent').val('');
    $('#txtTitle').focus();
}

function getBlogTable(){
    const lst = getBlogs();
    let htmlRows="";
    let count = 0;
    lst.forEach(item =>{
        const htmlRow = `
            <tr>
                <td>
                     <button class="btn btn-sm btn-outline-warning" onclick="editBlog('${item.id}')">Edit</button>
                     <button class="btn btn-sm btn-outline-danger" onclick="deleteBlog('${item.id}')">Delete</button>
                </td>                
                <td>${++count}</td>
                <td>${item.title}</td>
                <td>${item.author}</td>
                <td>${item.content}</td>
            </tr>
        `;
        htmlRows += htmlRow;
    });
    $('tBody').html(htmlRows);    
}