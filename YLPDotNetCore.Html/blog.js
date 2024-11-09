const tblBlog = "blogs";
let blogId = null;

//JQuery
getBlogTable();
// testPromise2();

// JS
// createBlog("JJ", "aa", "CC");
readBlogs();
// updateBlog("a295027a-d5a6-4fa1-bb2c-66cb46d594e5", "test", "test", "test");
// deleteBlog("a295027a-d5a6-4fa1-bb2c-66cb46d594e5");

function readBlogs() {
  const blogs = localStorage.getItem(tblBlog);
  console.log(blogs);
}

function editBlog(id) {
  let lst = getBlogs();
  let items = lst.filter((x) => x.id === id);
  if (items.length === 0) {
    console.log("no data found.");
    errorMessage("No data found.");
  }
  let item = items[0];
  blogId = item.id;
  $("#txtTitle").val(item.title);
  $("#txtAuthor").val(item.author);
  $("#txtContent").val(item.content);
}

function createBlog(title, author, content) {
  let lst = getBlogs();

  const requestModel = {
    id: uuidv4(),
    title: title,
    author: author,
    content: content,
  };

  lst.push(requestModel);
  let blogJson = JSON.stringify(lst);
  localStorage.setItem("blogs", blogJson);
}

function updateBlog(id, title, author, content) {
  let lst = getBlogs();

  let items = lst.filter((x) => x.id === id);
  // console.log(items);
  if (items.length == 0) {
    console.log("no data found.");
    return;
  }

  let item = items[0];
  item.id = id;
  item.title = title;
  item.author = author;
  item.content = content;

  let index = lst.findIndex((x) => x.id === id);
  lst[index] = item;

  const jsonBlog = JSON.stringify(lst);
  localStorage.setItem("blogs", jsonBlog);
}

// function deleteBlog2(id){
//     let result = confirm("Are you sure want to delete.");
//     if(!result) return;

//     let lst = getBlogs();
//     let items = lst.filter(x => x.id === id);
//     if(items.length === 0){
//         console.log("no data found.");
//         return;
//     }

//     lst = lst.filter(x => x.id !== id);
//     const jsonBlog = JSON.stringify(lst);
//     localStorage.setItem("blogs", jsonBlog);
//     successMessage("Deleting success.");
//     readBlogs();
//     getBlogTable();
// }

//Delete function with sweet alert
// function deleteBlog3(id) {
//   Swal.fire({
//     title: "Are you sure?",
//     text: "You won't be able to revert this!",
//     icon: "warning",
//     showCancelButton: true,
//     confirmButtonColor: "#3085d6",
//     cancelButtonColor: "#d33",
//     confirmButtonText: "Delete",
//   }).then((result) => {
//     if (!result.isConfirmed) return;
//     let lst = getBlogs();
//     let items = lst.filter((x) => x.id === id);
//     if (items.length === 0) {
//       error("No data found");
//     } else {
//       lst = lst.filter((x) => x.id != id);
//       let blogJson = JSON.stringify(lst);
//       localStorage.setItem("blogs", blogJson);
//       success("Deleting success.");
//     }

//     getBlogTable();
//   });
// }

function deleteBlog(id) {
    confirmMessage("Are you sure want to delete").then(function (value) {
    let lst = getBlogs();
    let items = lst.filter((x) => x.id === id);
    if (items.length === 0) {
      error("No data found");
    } else {
      lst = lst.filter((x) => x.id != id);
      let blogJson = JSON.stringify(lst);
      localStorage.setItem("blogs", blogJson);
      success("Deleting success.");
    }

    getBlogTable();
  });
}

// End sweet alert

function getBlogs() {
  const blogs = localStorage.getItem(tblBlog);
  let lst = [];
  if (blogs !== null) {
    lst = JSON.parse(blogs);
  }

  return lst;
}

//JQuery
$("#saveBtn").click(function () {
  console.log("click");
  const title = $("#txtTitle").val();
  const author = $("#txtAuthor").val();
  const content = $("#txtContent").val();

  if (blogId === null && title != "" && author != "" && content != "") {
    createBlog(title, author, content);
    //successMessage("Saving success.");
    success("Saving success");
    clearControls();
  } else if (
    (blogId !== null) & (title != "") &&
    author != "" &&
    content != ""
  ) {
    updateBlog(blogId, title, author, content);
    // successMessage("Saving success.");
    success("Saving success");
    clearControls();
  } else {
    error("All fields are required.");
  }

  blogId = null;
  getBlogTable();
});

$("#cancelBtn").click(function () {
  // console.log("cancel");
  error("Remove all data from form.");
  clearControls();
});

function clearControls() {
  $("#txtTitle").val("");
  $("#txtAuthor").val("");
  $("#txtContent").val("");
  $("#txtTitle").focus();
}

function getBlogTable() {
  const lst = getBlogs();
  let htmlRows = "";
  let count = 0;
  lst.forEach((item) => {
    const htmlRow = `
            <tr>
                <td>
                     <button class="btn btn-sm btn-outline-warning" onclick="editBlog('${
                       item.id
                     }')">Edit</button>
                     <button class="btn btn-sm btn-outline-danger" onclick="deleteBlog('${
                       item.id
                     }')">Delete</button>
                </td>                
                <td>${++count}</td>
                <td>${item.title}</td>
                <td>${item.author}</td>
                <td>${item.content}</td>
            </tr>
        `;
    htmlRows += htmlRow;
  });
  $("tBody").html(htmlRows);
}

function testPromise1() {
  let promise = new Promise(function (successFun, errorFun) {
    let result = confirm("Are you sure want to delet? ");
    if (result) {
      successFun();
    } else {
      errorFun();
    }
  });

  promise.then(
    function (value) {
      success("success");
    },
    function (value) {
      error("error");
    }
  );
}

function testPromise2() {
  let promise = new Promise(function (successFun, errorFun) {
    Swal.fire({
      title: "Are you sure?",
      text: "You won't be able to revert this!",
      icon: "warning",
      showCancelButton: true,
      confirmButtonColor: "#3085d6",
      cancelButtonColor: "#d33",
      confirmButtonText: "Delete",
    }).then((result) => {
      if (result.isConfirmed) {
        successFun();
      }
      errorFun();
    });
  });
  promise.then(
    function (value) {
      success("success");
    },
    function (value) {
      error("error");
    }
  );
}
