const app = new Vue({
  el: "#app",
  data: {
    todos: [],
    Task: '',
    Author: '',
    domain: 'http://localhost:49315/'
  },
  methods: {
    createEntry() {
      var obj = {};
      obj.Task = this.Task;
      obj.Author = this.Author;


      fetch('http://localhost:49315/api/entries', {
        method: 'post',
        headers: {
          "Content-type": "application/json"
        },
        body: JSON.stringify(obj)
      })
        // .then(json)
        .then(function (data) {
          console.log('Request succeeded with JSON response', data);
        })
        .catch(function (error) {
          console.log('Request failed', error);
        });
    }
  },
  mounted() {

  }
})
