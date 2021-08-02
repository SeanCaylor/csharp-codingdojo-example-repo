const head = {
  data: 0,
  next: {
    data: 1,
    next: {
      data: 2,
      next: {
        data: "this is just some data it can be any data type",
        next: null,
      },
    },
  },
};

console.log(head);

let runner = head;

while (runner !== null) {
  console.log(runner.data);
  runner = runner.next;
}

function recursiveTraversal(curr) {
  if (curr === null) {
    return;
  }

  console.log(curr.data);
  recursiveTraversal(curr.next);
}

recursiveTraversal(head);
