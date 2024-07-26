import { gql, useQuery } from "@apollo/client";
import { useEffect, useState } from "react";
import { BRAND_FIELDS, TYPE_FIELDS } from "./graphql/fragments";

const GET_PRODUCTS = gql`
  ${BRAND_FIELDS}
  ${TYPE_FIELDS}
  query GetProducts($take: Int, $skip: Int, $order: [ProductSortInput!]) {
    products(take: $take, skip: $skip, order: $order) {
      items {
        id
        name
        brand {
          ...BrandFields
        }
        type {
          ...TypeFields
        }
        price
      }
      totalCount
    }
  }
`;

const Products = () => {
  const [skip, setSkip] = useState(0);
  const take = 5;

  const { loading, error, data, refetch } = useQuery(GET_PRODUCTS, {
    variables: {
      take,
      skip,
      order: { price: "ASC" },
    },
  });

  const handleNext = () => {
    setSkip(skip + take);
  };

  const handlePrevious = () => {
    setSkip(skip - take);
  };

  const totalPages = data ? Math.ceil(data.products.totalCount / take) : 1;
  const currentPage = data ? Math.floor(skip / take) + 1 : 1;

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
      <div>
        <button onClick={handlePrevious} disabled={skip === 0}>
          Previous
        </button>
        <span>
          Page {currentPage} of {totalPages}
        </span>
        <button
          onClick={handleNext}
          disabled={skip + take >= data.products.totalCount}
        >
          Next
        </button>
      </div>
    </div>
  );
};

export default Products;
