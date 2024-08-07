import { useMutation } from "@apollo/client";
import { useState } from "react";
import { useUpdateProductMutation } from "./graphql/GraphQLService";
import { UPDATE_PRODUCT } from "./graphql/queries";

const UpdateProduct = () => {
  const [id, setId] = useState("");
  const [name, setName] = useState("");
  const [price, setPrice] = useState("");
  const { updateProduct, data, loading, error } = useUpdateProductMutation();

  const handleSubmit = async (e: { preventDefault: () => void }) => {
    console.log("--- handle product update ---");
    e.preventDefault();
    try {
      updateProduct({
        variables: {
          input: {
            id: btoa(`Product:${id}`),
            name,
            price: parseFloat(price),
          },
        },
      });
      console.log(error);
    } catch (err) {
      console.log(err);
    }
  };

  const renderErrorMessage = (error: any) => {
    if (!error) return null;

    switch (error.kind) {
      case "ArgumentError":
        return `${error.message} (Parameter: ${error.paramName})`;
      case "InvalidBrandIdError":
        return `${error.message} (${atob(error.id)})`;
      case "InvalidProductTypeIdError":
        return `${error.message} (${atob(error.id)})`;
      case "MaxStockThresholdToSmallError":
        return `${error.message} (Restock Threshold: ${error.restockThreshold}, Max Stock Threshold: ${error.maxStockThreshold})`;
      case "InvalidProductIdError":
        return `${error.message} (${atob(error.id)})`;
      case "InvalidOperationError":
        return `${error.message}`;
      default:
        return error.message;
    }
  };

  return (
    <div>
      <h2>Update Product with error handling</h2>
      <form onSubmit={handleSubmit}>
        <label>
          Product ID:
          <input
            type="text"
            value={id}
            onChange={(e) => setId(e.target.value)}
            required
          />
        </label>
        <br />
        <label>
          Name:
          <input
            type="text"
            value={name}
            onChange={(e) => setName(e.target.value)}
            required
          />
        </label>
        <br />
        <label>
          Price:
          <input
            type="number"
            step="0.01"
            value={price}
            onChange={(e) => setPrice(e.target.value)}
            required
          />
        </label>
        <br />
        <button type="submit" disabled={loading}>
          {loading ? "Updating..." : "Update Product"}
        </button>
      </form>
      {data && data.updateProduct.errors && (
        <div>
          <h3>Error:</h3>
          <p>{renderErrorMessage(data.updateProduct.errors[0])}</p>
        </div>
      )}

      {data && data.updateProduct.product && (
        <div>
          <h3>Product Updated:</h3>
          <p>ID: {data.updateProduct.product.id}</p>
          <p>Name: {data.updateProduct.product.name}</p>
          <p>Price: {data.updateProduct.product.price}</p>
        </div>
      )}
    </div>
  );
};

export default UpdateProduct;
