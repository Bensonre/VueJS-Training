import Vue from 'vue'
import axios from 'axios'

const client = axios.create({
  baseURL: 'https://localhost:44396/api/Reviews',
  json: true
})

export default {
  async execute(method, resource, data) {
    return client({
      method,
      url: resource,
      data,
      headers:{
        "Access-Control-Allow-Origin": "*"
      }
    }).then(req => {
      return req.data
    })
  },
  getAll(min, max) {
    const review=this.execute('get', '/');
    console.log(review)
    return review;
  },
  create(FoodId, id, review) {
    const data=({
        ID: id,
        foodId: FoodId,
        Text: review.text,
        Rating: review.rating,
        Name: review.name
    });
    console.log(data)
    return this.execute('post', '/', data);
  },
  update(id, data) {
    return this.execute('put', `/${id}`, data)
  },
  delete(id) {
    return this.execute('delete', `/${id}`)
  }
}