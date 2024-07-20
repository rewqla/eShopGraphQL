import "./App.css";
import { gql, useQuery } from "@apollo/client";

const GET_PRODUCTS = gql`
  query GetProducts($take: Int, $order: [ProductSortInput!]) {
    products(take: $take, order: $order) {
      items {
        id
        name
        brand {
          id
          name
        }
        type {
          id
        }
        price
      }
      totalCount
    }
  }
`;

function App() {
  const { loading, error, data } = useQuery(GET_PRODUCTS, {
    variables: {
      take: 5,
      order: { price: "ASC" },
    },
  });

  console.log(data);
  console.log(error);

  if (loading) return <p>Loading...</p>;
  if (error) return <p>Error: {error.message}</p>;

  return (
    <div>
      <h2>Products</h2>
      <p>Total Count: {data.products.totalCount}</p>
      <ul>
        {data.products.items.map((product: any) => (
          <li key={product.id}>
            <strong>{product.name}</strong> - ${product.price}
            <br />
            Brand: {product.brand.name}
          </li>
        ))}
      </ul>
    </div>
  );
}

export default App;
