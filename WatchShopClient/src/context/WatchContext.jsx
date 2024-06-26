import { createContext, useEffect, useRef, useState } from 'react';
import { toast } from 'react-toastify';
import { useSelector, useDispatch } from 'react-redux'
import { useGetWatchesQuery } from '../apis/admin/watchApi';

const WatchContext = createContext();


const WatchContextProvider = ({ children }) => {
  // Wishlist Modal
  const [showWishlist, setShowWishlist] = useState(false);

  const handleWishlistClose = () => setShowWishlist(false);
  const handleWishlistShow = () => setShowWishlist(true);

  // Cart Modal
  const [showCart, setShowCart] = useState(false);

  const handleCartClose = () => setShowCart(false);
  const handleCartShow = () => setShowCart(true);

  const { data, isLoading } = useGetWatchesQuery()
  const [watches, setWatches] = useState()


  // Video Modal
  const [showVideo, setShowVideo] = useState(false);

  const handleVideoClose = () => setShowVideo(false);
  const handleVideoShow = () => setShowVideo(true);

  // Header Category Button
  const [isCategoryOpen, setIsCategoryOpen] = useState(false)

  const handleCategoryBtn = () => {
    setIsCategoryOpen((prevState) => !prevState)
  }
  const categoryBtnRef = useRef(null);

  
  useEffect(() => {
    if (!isLoading && data) {
      setWatches(data.result);
    }
  }, [isLoading, data]);

  useEffect(() => {
    if (!isLoading && data) {
      setJeweleryArray(watches);
      setFilteredProducts(watches);
    }
  }, [watches]);

  useEffect(() => {
    const handleClickOutside = (event) => {
      if (categoryBtnRef.current && !categoryBtnRef.current.contains(event.target)) {
        // Click occurred outside the button, so close the button
        setIsCategoryOpen(false);
      }
    };

    // Attach the click event listener when the component mounts
    document.addEventListener('click', handleClickOutside);

    // Clean up the event listener when the component unmounts
    return () => {
      document.removeEventListener('click', handleClickOutside);
    };
  }, []);

  // Countdown Timer
  const countdownDate = new Date(Date.now() + 7 * 24 * 60 * 60 * 1000).getTime();
  const [isTimerState, setIsTimerState] = useState({
    days: 0,
    hours: 0,
    minutes: 0,
    seconds: 0,
  });

  useEffect(() => {
    setInterval(() => setNewTime(), 1000);
  }, []);

  const setNewTime = () => {
    if (countdownDate) {
      const currentTime = new Date().getTime();

      const distanceToDate = countdownDate - currentTime;

      let days = Math.floor(distanceToDate / (1000 * 60 * 60 * 24));
      let hours = Math.floor(
        (distanceToDate % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60),
      );
      let minutes = Math.floor(
        (distanceToDate % (1000 * 60 * 60)) / (1000 * 60),
      );
      let seconds = Math.floor((distanceToDate % (1000 * 60)) / 1000);

      const numbersToAddZeroTo = [1, 2, 3, 4, 5, 6, 7, 8, 9];

      days = `${days}`;
      if (numbersToAddZeroTo.includes(hours)) {
        hours = `0${hours}`;
      } else if (numbersToAddZeroTo.includes(minutes)) {
        minutes = `0${minutes}`;
      } else if (numbersToAddZeroTo.includes(seconds)) {
        seconds = `0${seconds}`;
      }

      setIsTimerState({ days: days, hours: hours, minutes, seconds });
    }
  };

  // Product Quick View Modal
  const [isProductViewOpen, setIsProductViewOpen] = useState(false)

  const handleProductViewClose = () => {
    setIsProductViewOpen(false)
  }
  const handleProductViewOpen = () => {
    setIsProductViewOpen(true)
  }

  // Sticky Header Section on Scroll
  const [isHeaderFixed, setIsHeaderFixed] = useState(true)

  useEffect(() => {
    const handleScroll = () => {
      if (window.scrollY >= 300) {
        setIsHeaderFixed(true);
      } else {
        setIsHeaderFixed(false);
      }
    };

    window.addEventListener('scroll', handleScroll);

    return () => {
      // Clean up the event listener when the component is unmounted
      window.removeEventListener('scroll', handleScroll);
    };
  }, []);

  // List View Mode
  const [isListView, setIsListView] = useState(false)

  const setListView = () => {
    setIsListView(true)
  }
  const setGridView = () => {
    setIsListView(false)
  }
  // Price Filter
  const [startPrice, setStartPrice] = useState(20);
  const [endPrice, setEndPrice] = useState(500);
  const [price, setPrice] = useState([startPrice, endPrice]);

  const handlePriceChange = (event, newPrice) => {
    setPrice(newPrice);
  };

  // All Product Filter
  const [filteredProducts, setFilteredProducts] = useState([]);
  const [sortBy, setSortBy] = useState('');
  const [active, setActive] = useState('');

  // Handle sort
  const handleSortChange = (event) => {
    const value = event.target.value;
    setSortBy(value);
    sortProducts(value);
  };
  // sort product
  const sortProducts = (criteria) => {
    let sortedProducts = [...filteredProducts];

    switch (criteria) {
        case 'name-az':
            sortedProducts.sort((a, b) => {
                if (a.nameModel < b.nameModel) return 1;
                if (a.nameModel > b.nameModel) return -1;
                return 0;
            });
            break;
        case 'name-za':
            sortedProducts.sort((a, b) => {
                if (a.nameModel > b.nameModel) return 1;
                if (a.nameModel < b.nameModel) return -1;
                return 0;
            });
            break;
        case 'price-low-high':
            sortedProducts.sort((a, b) => a.price - b.price);
            break;
        case 'price-high-low':
            sortedProducts.sort((a, b) => b.price - a.price);
            break;
        case 'default':
              sortedProducts.sort((a, b) => {
                if (a.brend.name < b.brend.name) return 1;
                if (a.brend.name > b.brend.name) return -1;
                return 0;
              });
              break;
        default:
            sortedProducts.sort((a, b) => {
                if (a.brend.name < b.brend.name) return 1;
                if (a.brend.name > b.brend.name) return -1;
                return 0;
              });
            break;
    }

    setFilteredProducts(sortedProducts);
};
  // category handle method
  const handleCategoryFilter = (brend) => {
    if (brend === null) {
      setFilteredProducts(jeweleryArray); // Show all products
    } else {
      const filtered = jeweleryArray.filter(watch => watch.brend.name === brend);
      setFilteredProducts(filtered);
    }
    setCurrentPage(1);
  };

  const handleGenderFilter = (gender) => {
    if (gender === null) {
      setrFilteredProducts(jeweleryArray);
    } else {
      const filtered = jeweleryArray.filter(watch => watch.gender === gender);
      setFilteredProducts(filtered);
    }
    setCurrentPage(1);
  };

  //style handle method
  const handleStyleFilter = (style) => {
    if (style === null) {
      setFilteredProducts(jeweleryArray);
    } else {
      const filtered = jeweleryArray.filter(watch => watch.style.name === style);
      setFilteredProducts(filtered);
    }
    setCurrentPage(1);
  };

  // Price Filter
  const handlePriceFilter = () => {
    const filtered = jeweleryArray.filter(watch => watch.price >= price[0] && watch.price <= price[1]);
    console.log(filtered)
    setFilteredProducts(filtered);
  };

  // Search Filter
  const [searchTerm, setSearchTerm] = useState('');
  const [searchedProducts, setSearchedProducts] = useState([]);

  const handleSearchChange = (event) => {
    const value = event.target.value;
    setSearchTerm(value);
    performSearch(value);
  };

  const performSearch = (term) => {
    const filtered = jeweleryArray.filter(watch =>
      watch.nameModel.toLowerCase().includes(term.toLowerCase())
    );
    setSearchedProducts(filtered);
  };

  useEffect(() => {
    if (searchTerm) {
      setFilteredProducts(searchedProducts);
      setCurrentPage(1); // Reset pagination when search changes
    } else {
      setFilteredProducts(jeweleryArray);
    }
  }, [searchedProducts, searchTerm]);
 // Tag Filter
 const [selectedTags, setSelectedTags] = useState([]);

  const handleTagSelection = (tag) => {
    if (selectedTags.includes(tag)) {
      setSelectedTags(selectedTags.filter((selectedTag) => selectedTag !== tag));
    } else {
      setSelectedTags([...selectedTags, tag]);
    }
  };
// Pagination
const productsPerPage = 9;
const [currentPage, setCurrentPage] = useState(1);

const totalProducts = filteredProducts.length;
const totalPages = Math.ceil(totalProducts / productsPerPage);

const handlePageChange = (newPage) => {
  setCurrentPage(newPage);
  scrollToTop(); // Scroll to the top after changing the page
};

// Scroll to the top of the page
const scrollToTop = () => {
  window.scrollTo({
    top: 0,
    behavior: "smooth", // You can also use "auto" for instant scrolling
  });
};

useEffect(() => {
  // Calculate the index range for pagination
  const startIndex = (currentPage - 1) * productsPerPage;
  const endIndex = currentPage * productsPerPage;

  // Slice the filtered products based on the calculated index range
  const paginatedSlice = filteredProducts.slice(startIndex, endIndex);

  // Set the paginated products
  setPaginatedProducts(paginatedSlice);

  // Scroll to the top whenever the page changes
}, [currentPage, filteredProducts]);

  // Use this state to store the paginated products
  const [paginatedProducts, setPaginatedProducts] = useState([]);

  // Cart Item Table 
  const [cartItems, setCartItems] = useState(JSON.parse(localStorage.getItem('cartItems')) == null ? [] : JSON.parse(localStorage.getItem('cartItems')));
  const cartItemAmount = cartItems.reduce((total, item) => total + item.quantity, 0);

  useEffect(() => {
      localStorage.setItem('cartItems', JSON.stringify(cartItems));
  }, [cartItems])

  const handleRemoveItem = (itemId) => {
    const updatedItems = cartItems.filter(item => item.id !== itemId);
    setCartItems(updatedItems);
    toast.error('Watch deleted from cart!')
  };
  const handleQuantityChange = (itemId, newQuantity) => {
    if (newQuantity >= 0) {
      if (newQuantity === 0) {
        handleRemoveItem(itemId); // Call the handleRemoveItem function
      } else {
        const updatedItems = cartItems.map(item =>
          item.id === itemId ? { ...item, quantity: newQuantity, total: item.price * newQuantity } : item
        );
        setCartItems(updatedItems);
      }
    }
  };

  const addToCartWithQuantity = (itemId, quantity) => {
    const itemToAdd = jeweleryArray.find(item => item.id === itemId);

    if (itemToAdd) {
      const existingItemIndex = cartItems.findIndex(item => item.id === itemId);

      if (!cartItems.some(item => item.id === itemId)) {

        let newItem = {
          quantity: quantity
        };

        if(itemToAdd.isDiscounted == true){
          newItem = {
            ...itemToAdd,
            quantity: quantity,
            total: itemToAdd.discountPrice
          };
        }
        else{
          newItem = {
            ...itemToAdd,
            quantity: quantity,
            total: itemToAdd.price
          };
        }

        setCartItems(prevCartItems => [...prevCartItems, newItem]);
        toast.success("Watch added in cart!")
      } else if (existingItemIndex !== -1) {

        const updatedCartItems = [...cartItems];
        updatedCartItems[existingItemIndex].quantity += quantity;

        if(itemToAdd.isDiscounted == true){
          updatedCartItems[existingItemIndex].total = updatedCartItems[existingItemIndex].quantity * itemToAdd.discountPrice;
        }
        else{
          updatedCartItems[existingItemIndex].total = updatedCartItems[existingItemIndex].quantity * itemToAdd.price;
        }

        setCartItems(updatedCartItems);
        toast.success("Watch list updated in cart!")

      }
    } else {
      toast.warning('Watch not found in watchesList.');
    }
  };

  // Add to Cart
  const addToCart = (itemId) => {
    // Find the item from allProductList using itemId
    const itemToAdd = jeweleryArray.find(item => item.id === itemId);

    if (itemToAdd) {
      const existingItemIndex = cartItems.findIndex(item => item.id === itemId);
      // Check if the item is already in the cart
      if (!cartItems.some(item => item.id === itemId)) {

        let newItem = {
          quantity: 0
        };

        if(itemToAdd.isDiscounted == true){
          newItem = {
            ...itemToAdd,
            quantity: 1,
            total: itemToAdd.discountPrice
          };
        }
        else{
          newItem = {
            ...itemToAdd,
            quantity: 1,
            total: itemToAdd.price
          };
        }
        // Set initial quantity to 1 and total to item's price

        setCartItems(prevCartItems => [...prevCartItems, newItem]);
        toast.success("Watch added in cart!")
      } else if (existingItemIndex !== -1) {
        // Increment quantity and update total
        const updatedCartItems = [...cartItems];
        updatedCartItems[existingItemIndex].quantity += 1;

        if(itemToAdd.isDiscounted == true){
          updatedCartItems[existingItemIndex].total = updatedCartItems[existingItemIndex].quantity * itemToAdd.discountPrice;
        }
        else{
          updatedCartItems[existingItemIndex].total = updatedCartItems[existingItemIndex].quantity * itemToAdd.price;
        }

        setCartItems(updatedCartItems);
        toast.success("Watch list updated in cart!")

      }
    } else {
      toast.warning('Watch not found in watchesList.');
    }
  };

  // Wishlist Item Table 
  const [wishlist, setWishlist] = useState(JSON.parse(localStorage.getItem('wishlist')) == null ? [] : JSON.parse(localStorage.getItem('wishlist')));
  const wishlistItemAmount = wishlist.reduce((total, item) => total + item.quantity, 0);

  useEffect(() => {
      localStorage.setItem('wishlist', JSON.stringify(wishlist));
  }, [wishlist])


  const handleRemoveItemWishlist = (itemId) => {
    const updatedItems = wishlist.filter(item => item.id !== itemId);
    setWishlist(updatedItems);
    toast.error("Watch deleted from wishlist!")
  };

  // Add to Wishlist

  const addToWishlist = (itemId) => {
    const itemToAdd = jeweleryArray.find(item => item.id === itemId);

    if (itemToAdd) {
      if (!wishlist.some(item => item.id === itemId)) {
        const newItem = {
          ...itemToAdd,
          quantity: 1,
          total: itemToAdd.price,
          isInWishlist: true
        };

        setWishlist(prevWishlistItems => [...prevWishlistItems, newItem]);
        toast.success("Watch added to wishlist!");
      } else {
        toast.warning("Watch already in wishlist!");
      }
    } else {
      toast.error('Watch not found in filteredProducts.');
    }
  };

  useEffect(() => {
    setFilteredProducts(prevFilteredProducts => {
      const updatedProductList = prevFilteredProducts.map(item => {
        if (wishlist.some(wishlistItem => wishlistItem.id === item.id)) {
          return {
            ...item,
            isInWishlist: true
          };
        } else {
          return {
            ...item,
            isInWishlist: false
          };
        }
      });
      return updatedProductList;
    });
  }, [wishlist]);

  // Function to add wishlist items to cart
  const addWishlistToCart = () => {
    if (wishlist.length === 0) {
      toast.warning("No watches in wishlist to add!");
      return;
    }
  
    const updatedCartItems = [...cartItems];
  
    wishlist.forEach((wishlistItem) => {
      const existingCartItemIndex = updatedCartItems.findIndex((cartItem) => cartItem.id === wishlistItem.id);
  
      if (existingCartItemIndex !== -1) {
        // If item exists in cart, update its quantity
        updatedCartItems[existingCartItemIndex].quantity += 1;
        updatedCartItems[existingCartItemIndex].total += wishlistItem.price;
      } else {
        // If item does not exist in cart, add it with quantity 1
        const newCartItem = {
          ...wishlistItem,
          quantity: 1,
          total: wishlistItem.price,
        };
        updatedCartItems.push(newCartItem);
      }
    });
  
    setCartItems(updatedCartItems);
    setWishlist([]); // Clear the wishlist after adding to cart
    toast.success("Wishlist watches added to cart!");
  };
  
  

  const addToCartFromWishlist = (item) => {
    const existingCartItemIndex = cartItems.findIndex((cartItem) => cartItem.id === item.id);
    const updatedWishlist = wishlist.filter((wishlistItem) => wishlistItem.id !== item.id); // Use a different parameter name
  
    if (existingCartItemIndex !== -1) {
      // If item exists in cart, update its quantity
      const updatedCartItems = [...cartItems];
      updatedCartItems[existingCartItemIndex].quantity += 1;
      updatedCartItems[existingCartItemIndex].total += item.price;
      setCartItems(updatedCartItems);
      toast.success("Watch quantity updated in cart!");
    } else {
      // If item does not exist in cart, add it with quantity 1
      const newCartItem = {
        ...item,
        quantity: 1,
        total: item.price,
      };
      setCartItems((prevCartItems) => [...prevCartItems, newCartItem]);
      setWishlist(updatedWishlist); // Update wishlist after removing the item
      toast.success("Watch added to cart!");
    }
  };

  // Total Price
  const subTotal = cartItems.reduce((total, item) => {
    const price = item.isDiscounted ? item.discountPrice : item.price;
    return total + item.quantity * price;
  }, 0);
  const finalPrice = subTotal

  // jewelery shop
  const [jeweleryArray, setJeweleryArray] = useState([]);
  const [jeweleryWishlist, setJeweleryWishlist] = useState([]);
  const wishlistJewelleryItemAmount = jeweleryWishlist.reduce((total, item) => total + item.quantity, 0);

  // random ornament array
  const [randomizedItems, setRandomizedItems] = useState([]);

  useEffect(() => {
    // Shuffle the array and store the shuffled order initially
    const shuffledItems = shuffleArray(jeweleryArray);
    setRandomizedItems(shuffledItems);
  }, []); // Empty dependency array, so the shuffle is done once on mount

  const handleRemoveJeweleryItemWishlist = (itemId) => {
    const updatedItems = jeweleryWishlist.filter(item => item.id !== itemId);
    setJeweleryWishlist(updatedItems);
    toast.error("Watch deleted from wishlist!");
  };

  const addToJeweleryWishlist = (itemId) => {
    const itemToAdd = jeweleryArray.find(item => item.id === itemId);

    if (itemToAdd) {
      if (!jeweleryWishlist.some(item => item.id === itemId)) {
        const newItem = {
          ...itemToAdd,
          quantity: 1,
          total: itemToAdd.price,
          isInWishlist: true
        };

        setJeweleryWishlist(prevWishlistItems => [...prevWishlistItems, newItem]);
        toast.success("Watch added to wishlist!");
      } else {
        toast.warning("Watch already in wishlist!");
      }
    } else {
      toast.error('Watch not found in filteredProducts.');
    }
  };

  const updateIsInWishlist = (itemsArray) => {
    return itemsArray.map(item => {
      if (jeweleryWishlist.some(wishlistItem => wishlistItem.id === item.id)) {
        return {
          ...item,
          isInWishlist: true
        };
      } else {
        return {
          ...item,
          isInWishlist: false
        };
      }
    });
  };

  useEffect(() => {
    setJeweleryArray(prevFilteredProducts => updateIsInWishlist(prevFilteredProducts));
    setRandomizedItems(prevRandomizedItems => updateIsInWishlist(prevRandomizedItems));
  }, [jeweleryWishlist]);

  // Jewelery add to cart array
  const [jeweleryAddToCart, setJeweleryAddToCart] = useState([]);
  // Jewelery cart total amount
  const jeweleryCartItemAmount = jeweleryAddToCart.reduce((total, item) => total + item.quantity, 0);
  // handle remove method for jewelery shop 
  const handleRemoveJeweleryCartItem = (itemId) => {
    const updatedItems = jeweleryAddToCart.filter(item => item.id !== itemId);
    setJeweleryAddToCart(updatedItems);
    toast.error("Watch deleted from wishlist!")
  };
  // handle quantity change for jewelery shop
  const handleJeweleryCartQuantityChange = (itemId, newQuantity) => {
    if (newQuantity === 0) {
      handleRemoveJeweleryCartItem(itemId); // Call the handleRemoveItem function
    } else {
      const updatedItems = jeweleryAddToCart.map(item =>
        item.id === itemId ? { ...item, quantity: newQuantity, total: item.price * newQuantity } : item
      );
      setJeweleryAddToCart(updatedItems);
    }
  };
  // Add to cart in jewelery shop
  const addToJeweleryCart = (itemId) => {
    const itemToAdd = jeweleryArray.find(item => item.id === itemId);

    if (itemToAdd) {
      const existingItemIndex = jeweleryAddToCart.findIndex(item => item.id === itemId);
      // Check if the item is already in the cart
      if (!jeweleryAddToCart.some(item => item.id === itemId)) {

        // Set initial quantity to 1 and total to item's price
        const newItem = {
          ...itemToAdd,
          quantity: 1,
          total: itemToAdd.price,
        };

        setJeweleryAddToCart(prevAddToCartItems => [...prevAddToCartItems, newItem]);
        toast.success("Watch added in AddToCart!")
      } else if (existingItemIndex !== -1) {
        // Increment quantity and update total
        const updatedAddToCartItems = [...jeweleryAddToCart];
        updatedAddToCartItems[existingItemIndex].quantity += 1;
        updatedAddToCartItems[existingItemIndex].total = updatedAddToCartItems[existingItemIndex].quantity * itemToAdd.price;

        setJeweleryAddToCart(updatedAddToCartItems);
        toast.success("Watch list updated in AddToCart!")
      }
    } else {
      toast.warning('Watch not found in ornament list.');
    }
  };

  // Function to shuffle an array using Fisher-Yates algorithm
  const shuffleArray = (array) => {
    const shuffledArray = [...array];
    for (let i = shuffledArray.length - 1; i > 0; i--) {
      const j = Math.floor(Math.random() * (i + 1));
      [shuffledArray[i], shuffledArray[j]] = [shuffledArray[j], shuffledArray[i]];
    }
    return shuffledArray;
  };

  // Right Sidebar
  const [isSidebarOpen, setIsSidebarOpen] = useState(false);

  const handleSidebarOpen = () => {
    setIsSidebarOpen(true)
  }
  const handleSidebarClose = () => {
    setIsSidebarOpen(false)
  }
  const [isDropdownOpen, setIsDropdownOpen] = useState({
    home:false,
    shop:false,
    pages:false,
    blog:false,
  })
  const handleDropdownToggle = (dropdownName) => {
    setIsDropdownOpen((prevState) => ({
      ...prevState,
      [dropdownName]: !prevState[dropdownName],
    }));
  };

  // Responsive Slider
  const [slides, setSlides] = useState(0);

  const setSlidesPerview = () => {
    setSlides(
      window.innerWidth <= 320
      ? 1
      : window.innerWidth <= 767
      ? 2
      : window.innerWidth <=  992
      ? 3
      : window.innerWidth >  992
      ? 4
      : 0
    );
  };

  useEffect(() => {
    //Initially set the amount of slides on page load
    setSlidesPerview();
    // Add the event listener on component mount
    window.addEventListener("resize", setSlidesPerview);

    // Remove the listener when component unmounts
    return () => {
      window.removeEventListener("resize", setSlidesPerview);
    };
  }, []);

  // Brand Slider
  const [slidesBrand, setSlidesBrand] = useState(0);

    const setSlidesBrandPerview = () => {
      setSlidesBrand(
        window.innerWidth <= 767
        ? 3
        : window.innerWidth <=  992
        ? 4
        : window.innerWidth >  992
        ? 5
        : 0
      );
    };
  
    useEffect(() => {
      //Initially set the amount of slides on page load
      setSlidesBrandPerview();
      // Add the event listener on component mount
      window.addEventListener("resize", setSlidesBrandPerview);
  
      // Remove the listener when component unmounts
      return () => {
        window.removeEventListener("resize", setSlidesBrandPerview);
      };
    }, []);

  return (
    <WatchContext.Provider value={{
      showWishlist,
      handleWishlistClose,
      handleWishlistShow,
      showCart,
      handleCartClose,
      handleCartShow,
      showVideo,
      handleVideoClose,
      handleVideoShow,
      isCategoryOpen,
      handleCategoryBtn,
      categoryBtnRef,
      isTimerState,
      isProductViewOpen,
      handleProductViewClose,
      handleProductViewOpen,
      isHeaderFixed,
      isListView,
      setListView,
      setGridView,
      price,
      handlePriceChange,
      filteredProducts,
      sortBy,
      handleSortChange,
      sortProducts,
      active,
      setActive,
      handleCategoryFilter,
      handleGenderFilter,
      handleStyleFilter,
      handlePriceFilter,
      currentPage,
      handlePageChange,
      totalPages,
      paginatedProducts,
      productsPerPage,
      totalProducts,
      cartItems,
      setCartItems,
      handleQuantityChange,
      handleRemoveItem,
      wishlist,
      handleRemoveItemWishlist,
      setFilteredProducts,
      addToCart,
      cartItemAmount,
      addToWishlist,
      subTotal,
      finalPrice,
      jeweleryWishlist,
      addToJeweleryWishlist,
      jeweleryAddToCart,
      addToJeweleryCart,
      jeweleryCartItemAmount,
      handleRemoveJeweleryItemWishlist,
      handleRemoveJeweleryCartItem,
      handleJeweleryCartQuantityChange,
      searchTerm,
      handleSearchChange,
      jeweleryArray,
      randomizedItems,
      addWishlistToCart,
      addToCartFromWishlist,
      addToCartWithQuantity,
      isSidebarOpen,
      handleSidebarOpen,
      handleSidebarClose,
      isDropdownOpen,
      handleDropdownToggle,
      slides,
      selectedTags,
      handleTagSelection,
      wishlistItemAmount,
      slidesBrand,
      wishlistJewelleryItemAmount
    }}>
      {children}
    </WatchContext.Provider>
  );
}

export { WatchContext, WatchContextProvider }
