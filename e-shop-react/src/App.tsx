import "./App.css";
import BrandByNameAndId from "./BrandByNameAndId";
import Brands from "./Brands";
import CreateBrand from "./CreateBrand";
import Products from "./products";
import UpdateProduct from "./UpdateProduct";

function App() {
  return (
    <>
      <Products />
      <Brands />
      <CreateBrand />
      <BrandByNameAndId name="Solstix" id="QnJhbmQ6MTA=" />
      <UpdateProduct />
    </>
  );
}

export default App;
