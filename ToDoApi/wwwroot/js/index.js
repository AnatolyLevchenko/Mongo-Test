const app = new Vue({
  el: "#app",
  data: {
    todos: [],
    Task: '',
    Author: '',
    created: false,
  },
  methods: {
    createEntry() {
      var obj = {};
      obj.Task = this.Task;
      obj.Author = this.Author;
      var self = this;

      fetch('/api/entries', {
        method: 'post',
        headers: {
          "Content-type": "application/json"
        },
        body: JSON.stringify(obj)
      })
        // .then(json)
        .then(function (data) {
          self.created = true;
          setTimeout(() => {
            self.created = false;
          }, 2000)
        })
        .catch(function (error) {
          alert('Request failed', error);
        });
    },
    getEntries() {
      fetch('/api/entries', {
        method: 'get',
        headers: {
          "Content-type": "application/json"
        },
      })
        .then(response => {
          response.json().then(json => {
            this.todos = json;
          })
        })

        .catch(function (error) {
          alert('Request failed', error);
        });
    }
  },
  created() {
    this.getEntries();
  }
})
