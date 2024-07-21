import React, { useState } from "react";
import { gql, useMutation } from "@apollo/client";

const CREATE_BRAND = gql`
  mutation CreateBrand($input: CreateBrandInput!) {
    createBrand(input: $input) {
      brand {
        id
        name
      }
    }
  }
`;

const CreateBrand = () => {
  const [name, setName] = useState("");
  const [createBrand, { data, loading, error }] = useMutation(CREATE_BRAND);

  const handleSubmit = async (e: { preventDefault: () => void }) => {
    e.preventDefault();
    try {
      await createBrand({ variables: { input: { name } } });
    } catch (err) {
      console.error(err);
    }
  };

  return (
    <div>
      <h2>Create Brand</h2>
      <form onSubmit={handleSubmit}>
        <label>
          Name:
          <input
            type="text"
            value={name}
            onChange={(e) => setName(e.target.value)}
          />
        </label>
        <button type="submit">Create</button>
      </form>
      {loading && <p>Loading...</p>}
      {error && <p>Error: {error.message}</p>}
      {data && (
        <p>
          Created brand with ID: {data.createBrand.brand.id} and Name:{" "}
          {data.createBrand.brand.name}
        </p>
      )}
    </div>
  );
};

export default CreateBrand;
