<template>
  <div class="foods">
    <img src="../assets/pie.gif" :alt="imgDes"> <!-- seems to no work with v-binding source have to check to see how images are being served-->
    <div class="food-nav">
    <h1 v-for="(food, index) in Food"
         :key="food.Id"
         class="foodtypes"
         @mouseover="updateProduct(index)">
    {{food.type}}
    </h1>
    </div>
    <div>
      <div>
        <h2>Food: {{currFood.type}}</h2>
        <div>
          <div>
            <span class="section-title"><em>Description:</em>{{currFood.des}}</span>
          </div>
          <div>
          <span v-if="currFood.CalCount"><em>calories:</em>{{currFood.CalCount}}</span>
          <form v-else>
            <p>
              <em>Calories not found!</em>
              <label for="Calories">Input Calories:</label>
              <input id="Calories" v-model.number.lazy="currFood.CalCount" placeholder="0">
            </p>
          </form>
          <div>
          <span><em>Taste: </em>{{currFood.taste}}</span>
          </div>
          </div>

        </div>
      </div>
    </div>
    <div>
    <h2>Make a review</h2>
    <review-form></review-form>
    <h2> Reviews </h2>
    <reviews-list></reviews-list>
    </div>
  </div>
</template>

<script>
  import Reviews from './Reviews.vue'
export default {
  name: 'foods',
  data () {
    return {
      selectedFood:0,
      Food: [
        {
          type: 'Pie',
          image: '/assets/pie.gif',
          ID: 314,
          des: 'A Pie',
          CalCount: 600,
          taste: 'Beyond',
          reviews: []
        },
        {
          type: 'Sushi',
          image: './assets/pie.png',
          ID: 315,
          des: 'Sushi',
          CalCount: 340,
          taste: 'Best',
          reviews: []
        },
        {
          type: 'Burger',
          image: './assets/pie.jpg',
          ID: 316,
          des: 'One juicy Burger Boi',
          CalCount: 750,
          taste: 'Delicious',
          reviews: []
        },
        {
          type: 'Day Old Oatmeal',
          image: './assets/pie.jpg',
          ID: 317,
          des: 'Woulda been good yesterday',
          CalCount: 0,
          taste: 'meh',
          reviews: []
        },
        ],
    }
    },
    computed: {
      image() {
        return this.Food[this.selectedFood].image
      },
      imgDes() {
        return this.Food[this.selectedFood].des
      },
      currFood() {
        return this.Food[this.selectedFood]
      }

    },
    methods: {
      updateProduct: function (index) {
        this.selectedFood = index
        console.log(index)
      }
    },
    components: {
      "review-form":Reviews
    }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style>
  .food-nav {
    display: flex;
    align-items: center;
    justify-content: center;
  }
h1 {
  font-weight: normal;
  margin: 10px;
  text-decoration:underline;
}
h2{
  font-weight:normal;
}

ul {
  list-style-type: none;
  padding: 0;
}

li {
  display: inline-block;
  margin: 0 10px;
}

a {
  color: #35495E;
}
</style>
