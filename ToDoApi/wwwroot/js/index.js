const app = new Vue({
  el: "#app",
  data: {
    name: 'You loaded this page on ' + new Date().toLocaleString()
  },
  template: `
    <div id='container'>
      <span>ToDo list</span>
    </div>`,
  methods: {

  },
  mounted() {

  }
})
