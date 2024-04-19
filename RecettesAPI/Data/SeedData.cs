using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using RecettesAPI.Models;
using System;
using System.Linq;
using MongoDB.Bson;

namespace RecettesAPI.Data
{
    public class SeedData
    {
        public static void Initialize(IMongoDatabase database)
        {
            var recipesCollection = database.GetCollection<Recette>("Recette");
            var categoriesCollection = database.GetCollection<Categories>("Categories");
            var ingredientsCollection = database.GetCollection<Ingredients>("ingredients");
            if (recipesCollection.AsQueryable().Any())
            {
                return;
            }

            //SeedRecipes(database);
            SeedCategories(database);
            SeedIngredients(database);
            SeedRecipes(database);

            Console.WriteLine("Seed data ajouté avec succès!");
        }

        private static void SeedIngredients(IMongoDatabase database)
        {
            var Ingredients = new[]
            {
                new Ingredients
                {
                    Name = "Oil",
                    Photo_url = "https://ak7.picdn.net/shutterstock/videos/27252067/thumb/11.jpg"
                },
                new Ingredients
                {
                    Name = "Salt",
                    Photo_url =
                        "https://image.freepik.com/free-photo/sea-salt-wooden-bowl-isolated-white-background_29402-416.jpg"
                },
                new Ingredients
                {
                    Name = "Russet potatoes",
                    Photo_url = "http://www.valleyspuds.com/wp-content/uploads/Russet-Potatoes-cut.jpg"
                },
                new Ingredients
                {
                    Name = "Paprika",
                    Photo_url =
                        "https://image.freepik.com/free-photo/red-chilli-pepper-powder-isolated-white-background_55610-28.jpg"
                },
                new Ingredients
                {
                    Name = "Black Pepper",
                    Photo_url = "https://ak0.picdn.net/shutterstock/videos/26741680/thumb/1.jpg"
                },
                new Ingredients
                {
                    Name = "Celery salt",
                    Photo_url = "https://www.hasiroglugurme.com/images/urunler/Koftelik-Esmer-Bulgur-resim-297.jpg"
                },
                new Ingredients
                {
                    Name = "Dried sage",
                    Photo_url =
                        "https://d2v9y0dukr6mq2.cloudfront.net/video/thumbnail/Esxjvv7/super-slow-motion-dried-sage-falling-on-white-background_n1xg2gxzg__F0000.png"
                },
                new Ingredients
                {
                    Name = "Garlic powder",
                    Photo_url =
                        "https://us.123rf.com/450wm/belchonock/belchonock1808/belchonock180818180/106007144-bowl-of-dry-garlic-powder-on-white-background.jpg?ver=6"
                },
                new Ingredients
                {
                    Name = "Ground allspice",
                    Photo_url =
                        "https://www.savoryspiceshop.com/content/mercury_modules/cart/items/2/6/9/2695/allspice-berries-jamaican-ground-1.jpg"
                },
                new Ingredients
                {
                    Name = "Dried oregano",
                    Photo_url = "https://frutascharito.es/886-large_default/oregano.jpg"
                },
                new Ingredients
                {
                    Name = "Dried basil",
                    Photo_url = "https://www.honeychop.com/wp-content/uploads/2015/09/Dried-Mint.png"
                },
                new Ingredients
                {
                    Name = "Dried marjoram",
                    Photo_url = "https://images-na.ssl-images-amazon.com/images/I/71YATIBqBYL._SX355_.jpg"
                },
                new Ingredients
                {
                    Name = "All-purpose flour",
                    Photo_url = "https://images.assetsdelivery.com/compings_v2/seregam/seregam1309/seregam130900036.jpg"
                },
                new Ingredients
                {
                    Name = "Brown sugar",
                    Photo_url =
                        "https://d2v9y0dukr6mq2.cloudfront.net/video/thumbnail/BALQTtekliuc6iu4u/rotating-brown-sugar-in-a-white-container-on-white-background_sis0xtbyl_thumbnail-full01.png"
                },
                new Ingredients
                {
                    Name = "Kosher salt",
                    Photo_url =
                        "https://d1yn1kh78jj1rr.cloudfront.net/image/preview/r64-6MxPQjlatyfjp/storyblocks-top-view-of-ceramic-salt-cellar-with-coarse-grained-sea-salt-isolated-on-white-background_SPzKionPuV_SB_PM.jpg"
                },
                new Ingredients
                {
                    Name = "Whole chicken",
                    Photo_url =
                        "https://image.shutterstock.com/image-photo/two-raw-chicken-drumsticks-isolated-260nw-632125991.jpg"
                },
                new Ingredients
                {
                    Name = "Eggs",
                    Photo_url =
                        "https://image.shutterstock.com/image-photo/egg-whites-yolk-cup-isolated-260nw-1072453787.jpg"
                },
                new Ingredients
                {
                    Name = "Quarts neutral oil",
                    Photo_url =
                        "https://imagesvc.meredithcorp.io/v3/mm/image?url=https%3A%2F%2Fimg1.cookinglight.timeinc.net%2Fsites%2Fdefault%2Ffiles%2Fstyles%2F4_3_horizontal_-_1200x900%2Fpublic%2Fgettyimages-464433694_0.jpg%3Fitok%3DK42YR2GV&w=400&c=sc&poi=face&q=85"
                },
                new Ingredients
                {
                    Name = "Water",
                    Photo_url = "https://ak1.picdn.net/shutterstock/videos/829561/thumb/11.jpg"
                },
                new Ingredients
                {
                    Name = "Onion Powder",
                    Photo_url =
                        "https://image.shutterstock.com/image-photo/mixed-spices-isolated-on-white-260nw-662383828.jpg"
                },
                new Ingredients
                {
                    Name = "MSG",
                    Photo_url =
                        "https://img.freepik.com/free-photo/monosodium-glutamate-wood-spoon-white-background_55883-399.jpg?size=626&ext=jpg"
                },
                new Ingredients
                {
                    Name = "Chicken Breast",
                    Photo_url =
                        "https://us.123rf.com/450wm/utima/utima1602/utima160200063/53405187-raw-chicken-breast-fillets.jpg?ver=6"
                },
                new Ingredients
                {
                    Name = "Onion chopped",
                    Photo_url = "https://s3.envato.com/files/246703499/IMG_1752_5.jpg"
                },
                new Ingredients
                {
                    Name = "Tomato paste",
                    Photo_url =
                        "http://d3e1m60ptf1oym.cloudfront.net/45bab59a-363c-11e1-ab4e-bf4c2e0bb026/PANELA_xgaplus.jpg"
                },
                new Ingredients
                {
                    Name = "Chilli Powder",
                    Photo_url =
                        "https://us.123rf.com/450wm/nuttapong/nuttapong1505/nuttapong150500009/40458002-paprika-powder-isolated-on-white-background.jpg?ver=6"
                },
                new Ingredients
                {
                    Name = "Ground Beef",
                    Photo_url =
                        "https://images.radio.com/kmoxam/s3fs-public/styles/nts_image_cover_tall_775x425/public/dreamstime_s_39607998.jpg?XCM.w1UGOp9sVKkWGQZe7_JIsRddxoIK&itok=3M6KcFLH&c=73fb6497175b4c1a5c79e3ede816656a"
                },
                new Ingredients
                {
                    Name = "Can kidney beans, rinsed and drained",
                    Photo_url =
                        "https://www.seriouseats.com/images/2014/04/20140414-pile-of-beans-primary-1500x1125.jpg"
                },
                new Ingredients
                {
                    Name = "Large Tortillas",
                    Photo_url = "https://upload.wikimedia.org/wikipedia/commons/5/56/NCI_flour_tortillas.jpg"
                },
                new Ingredients
                {
                    Name = "Fritos",
                    Photo_url =
                        "https://previews.123rf.com/images/ksena32/ksena321510/ksena32151000090/45863494-fried-fish-on-a-white-background.jpg"
                },
                new Ingredients
                {
                    Name = "Shredded cheddar",
                    Photo_url =
                        "https://image.shutterstock.com/image-photo/top-view-small-bowl-filled-260nw-284460308.jpg"
                },
                new Ingredients
                {
                    Name = "Lime",
                    Photo_url = "https://ak8.picdn.net/shutterstock/videos/23271748/thumb/1.jpg"
                },
                new Ingredients
                {
                    Name = "Ground cumin",
                    Photo_url =
                        "https://image.shutterstock.com/image-photo/pile-cumin-powder-isolated-on-260nw-1193262853.jpg"
                },
                new Ingredients
                {
                    Name = "Cayenne pepper",
                    Photo_url = "https://ak7.picdn.net/shutterstock/videos/11461337/thumb/1.jpg"
                },
                new Ingredients
                {
                    Name = "Flaky white fish",
                    Photo_url =
                        "https://image.shutterstock.com/image-photo/roach-river-fish-isolated-on-260nw-277764143.jpg"
                },
                new Ingredients
                {
                    Name = "Avocado",
                    Photo_url =
                        "https://www.redwallpapers.com/public/redwallpapers-large-thumb/avocado-cut-stone-leaves-white-background-free-stock-photos-images-hd-wallpaper.jpg"
                },
                new Ingredients
                {
                    Name = "Red Pepper Flakes",
                    Photo_url =
                        "https://as1.ftcdn.net/jpg/02/06/55/10/500_F_206551074_mVczUrAWOSMaw8kR48FQDQBqDw47jCtL.jpg"
                },
                new Ingredients
                {
                    Name = "Onions",
                    Photo_url = "http://www.allwhitebackground.com/images/2/2650.jpg"
                },
                new Ingredients
                {
                    Name = "Green Pepper",
                    Photo_url = "https://ak9.picdn.net/shutterstock/videos/4055509/thumb/1.jpg"
                },
                new Ingredients
                {
                    Name = "Red Pepper",
                    Photo_url = "https://ak9.picdn.net/shutterstock/videos/10314179/thumb/1.jpg"
                },
                new Ingredients
                {
                    Name = "Pizza dough",
                    Photo_url =
                        "https://image.shutterstock.com/image-photo/fresh-raw-dough-pizza-bread-260nw-518950903.jpg"
                },
                new Ingredients
                {
                    Name = "Ketchup sauce",
                    Photo_url =
                        "https://st2.depositphotos.com/5262887/11050/i/950/depositphotos_110501208-stock-photo-ketchup-bowl-isolated-on-white.jpg"
                },
                new Ingredients
                {
                    Name = "Hot Sauce",
                    Photo_url =
                        "https://media.istockphoto.com/photos/opened-can-of-spaghetti-sauce-on-a-white-background-picture-id497704752?k=6&m=497704752&s=612x612&w=0&h=JnL54buYu1Z3fGtd8uNdjFxiAKwlxoDluD6jbIfSaZI="
                },
                new Ingredients
                {
                    Name = "Butter",
                    Photo_url = "https://redrockstoffee.com/media/2016/11/AdobeStock_76417550.jpeg"
                },
                new Ingredients
                {
                    Name = "Heavy Cream",
                    Photo_url =
                        "https://media.istockphoto.com/photos/mayonnaise-in-bowl-isolated-on-white-background-picture-id614981116?k=6&m=614981116&s=612x612&w=0&h=LtbsI2HQXOTERYuP9YJ2PJfRF3W6DcyZ798fxMcQWC0="
                },
                new Ingredients
                {
                    Name = "Whole-milk plain yogurt",
                    Photo_url =
                        "https://st.depositphotos.com/2757384/3317/i/950/depositphotos_33170129-stock-photo-pouring-a-glass-of-milk.jpg"
                },
                new Ingredients
                {
                    Name = "Cheese",
                    Photo_url = "https://ak7.picdn.net/shutterstock/videos/3619997/thumb/1.jpg"
                },
                new Ingredients
                {
                    Name = "Mozzarella",
                    Photo_url =
                        "https://t3.ftcdn.net/jpg/02/06/73/98/500_F_206739841_suPu6qDPHlowFqx9qo8fLqV8sNevL2g3.jpg"
                },
                new Ingredients
                {
                    Name = "Celery stalks",
                    Photo_url =
                        "https://cdn4.eyeem.com/thumb/6d1b3957c7caa9b73c3e0f820ef854b931808139-1538043742765/w/750"
                },
                new Ingredients
                {
                    Name = "Parmesan Cheese",
                    Photo_url = "https://ak7.picdn.net/shutterstock/videos/3721877/thumb/1.jpg"
                },
                new Ingredients
                {
                    Name = "Pancetta",
                    Photo_url =
                        "https://previews.123rf.com/images/onlyfabrizio/onlyfabrizio1606/onlyfabrizio160600002/60198502-raw-stripes-of-pancetta-stesa-on-a-white-background.jpg"
                },
                new Ingredients
                {
                    Name = "Spaghetti",
                    Photo_url =
                        "https://previews.123rf.com/images/mfron/mfron1204/mfron120400098/13306773-bunch-of-spaghetti-nudeln-isoliert-auf-wei%C3%9Fem-hintergrund.jpg"
                },
                new Ingredients
                {
                    Name = "Garlic",
                    Photo_url = "https://image.freepik.com/free-photo/fresh-garlic-white-background_1339-17012.jpg"
                },
                new Ingredients
                {
                    Name = "Lasagna noodles",
                    Photo_url =
                        "https://previews.123rf.com/images/velkol/velkol1110/velkol111000004/11083085-an-image-of-raw-lasagna-on-white-background.jpg"
                },
                new Ingredients
                {
                    Name = "Italian sauce",
                    Photo_url =
                        "https://previews.123rf.com/images/arinahabich/arinahabich1504/arinahabich150400858/38827029-raw-italian-sausage-on-a-white-background-.jpg"
                },
                new Ingredients
                {
                    Name = "Crushed Tomatoes",
                    Photo_url =
                        "https://previews.123rf.com/images/merkulovnik/merkulovnik1406/merkulovnik140600100/28751626-crushed-tomato-isolated-on-white-background.jpg"
                },
                new Ingredients
                {
                    Name = "Sugar",
                    Photo_url =
                        "https://previews.123rf.com/images/sommai/sommai1411/sommai141100034/33199985-sugar-cubes-in-a-bowl-isolated-on-white-background.jpg"
                },
                new Ingredients
                {
                    Name = "Minced fresh parsley",
                    Photo_url =
                        "https://t4.ftcdn.net/jpg/02/15/78/05/240_F_215780551_Eid0xpP1M2fokvuEcvJj8uqhROLJkb3p.jpg"
                },
                new Ingredients
                {
                    Name = "Ricotta cheese",
                    Photo_url =
                        "https://previews.123rf.com/images/barkstudio/barkstudio1608/barkstudio160800351/61418602-ricotta-cheese-into-a-bowl-in-white-background.jpg"
                },
                new Ingredients
                {
                    Name = "Fennel seed",
                    Photo_url =
                        "https://previews.123rf.com/images/pinkomelet/pinkomelet1710/pinkomelet171000227/88851299-close-up-the-fennel-seed-on-white-background.jpg"
                },
                new Ingredients
                {
                    Name = "Banana",
                    Photo_url = "https://www.conservationmagazine.org/wp-content/uploads/2013/04/sterile-banana.jpg"
                },
                new Ingredients
                {
                    Name = "Frozen Strawberries",
                    Photo_url = "https://www.cascadianfarm.com/wp-content/uploads/2018/12/Strawberries_Main_0218.png"
                },
                new Ingredients
                {
                    Name = "Greek Yogurt",
                    Photo_url = "http://images.media-allrecipes.com/userphotos/960x960/3758635.jpg"
                }
            };

            var collection = database.GetCollection<Ingredients>("Ingredients");
            collection.InsertMany(Ingredients);
        }

        private static void SeedCategories(IMongoDatabase database)
        {
            var Categories = new[]
            {
                new Categories
                {
                    Name = "Cookies",
                    Photourl =
                        "https://www.telegraph.co.uk/content/dam/Travel/2019/January/france-food.jpg?imwidth=1400"
                },
                new Categories
                {
                    Name = "Mexican Food",
                    Photourl = "https://ak1.picdn.net/shutterstock/videos/19498861/thumb/1.jpg"
                },
                new Categories
                {
                    Name = "Italian Food",
                    Photourl =
                        "https://images.unsplash.com/photo-1533777324565-a040eb52facd?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&w=1000&q=80"
                },
                new Categories
                {
                    Name = "Smoothies",
                    Photourl =
                        "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/still-life-of-three-fresh-smoothies-in-front-of-royalty-free-image-561093647-1544042068.jpg?crop=0.715xw:0.534xh;0.0945xw,0.451xh&resize=768:*"
                },
                new Categories
                {
                    Name = "Pizza",
                    Photourl = "https://amp.businessinsider.com/images/5c084bf7bde70f4ea53f0436-750-563.jpg"
                },
            };
            var collection = database.GetCollection<Categories>("Categories");
            collection.InsertMany(Categories);
        }


        private static void SeedRecipes(IMongoDatabase database)
        {
            var categoriesCollection = database.GetCollection<Categories>("Categories");
            var ingredientsCollection = database.GetCollection<Ingredients>(nameof(Ingredients));

            var cookiesCategoryId = categoriesCollection.Find(c => c.Name == "Cookies").FirstOrDefault()?.Id_categorie;
            var mexicanFoodCategoryId =
                categoriesCollection.Find(c => c.Name == "Mexican Food").FirstOrDefault()?.Id_categorie;
            var italianFoodCategoryId =
                categoriesCollection.Find(c => c.Name == "Italian Food").FirstOrDefault()?.Id_categorie;
            var smoothiesCategoryId =
                categoriesCollection.Find(c => c.Name == "Smoothies").FirstOrDefault()?.Id_categorie;
            var pizzaCategoryId = categoriesCollection.Find(c => c.Name == "Pizza").FirstOrDefault()?.Id_categorie;

            /*0*/
            var oilIngredientId = ingredientsCollection.Find(i => i.Name == "Oil").FirstOrDefault()?.IngredientId;
            /*1*/
            var saltIngredientId = ingredientsCollection.Find(i => i.Name == "Salt").FirstOrDefault()?.IngredientId;
            /*2*/
            var russetPotatoesIngredientId = ingredientsCollection.Find(i => i.Name == "Russet potatoes")
                .FirstOrDefault()?.IngredientId;
            /*3*/
            var paprikaIngredientId =
                ingredientsCollection.Find(i => i.Name == "Paprika").FirstOrDefault()?.IngredientId;
            /*4*/
            var blackPepperIngredientId =
                ingredientsCollection.Find(i => i.Name == "Black pepper").FirstOrDefault()?.IngredientId;
            /*5*/
            var celerySaltIngredientId =
                ingredientsCollection.Find(i => i.Name == "Celery salt").FirstOrDefault()?.IngredientId;
            /*6*/
            var driedSageIngredientId =
                ingredientsCollection.Find(i => i.Name == "Dried sage").FirstOrDefault()?.IngredientId;
            /*7*/
            var garlicPowderIngredientId = ingredientsCollection.Find(i => i.Name == "Garlic powder").FirstOrDefault()
                ?.IngredientId;
            /*8*/
            var groundAllspiceIngredientId = ingredientsCollection.Find(i => i.Name == "Ground allspice")
                .FirstOrDefault()?.IngredientId;
            /*9*/
            var driedOreganoIngredientId = ingredientsCollection.Find(i => i.Name == "Dried oregano").FirstOrDefault()
                ?.IngredientId;
            /*10*/
            var driedBasilIngredientId =
                ingredientsCollection.Find(i => i.Name == "Dried basil").FirstOrDefault()?.IngredientId;
            /*11*/
            var driedMarjoramIngredientId = ingredientsCollection.Find(i => i.Name == "Dried marjoram").FirstOrDefault()
                ?.IngredientId;
            /*12*/
            var allPurposeFlourIngredientId = ingredientsCollection.Find(i => i.Name == "All-purpose flour")
                .FirstOrDefault()?.IngredientId;
            /*13*/
            var brownSugarIngredientId =
                ingredientsCollection.Find(i => i.Name == "Brown sugar").FirstOrDefault()?.IngredientId;
            /*14*/
            var kosherSaltIngredientId =
                ingredientsCollection.Find(i => i.Name == "Kosher salt").FirstOrDefault()?.IngredientId;
            /*15*/
            var wholeChickenIngredientId = ingredientsCollection.Find(i => i.Name == "Whole chicken").FirstOrDefault()
                ?.IngredientId;
            /*16*/
            var eggsIngredientId = ingredientsCollection.Find(i => i.Name == "Eggs").FirstOrDefault()?.IngredientId;
            /*17*/
            var quartsNeutralOilIngredientId = ingredientsCollection.Find(i => i.Name == "Quarts neutral oil")
                .FirstOrDefault()?.IngredientId;
            /*18*/
            var waterIngredientId = ingredientsCollection.Find(i => i.Name == "Water").FirstOrDefault()?.IngredientId;
            /*19*/
            var onionPowderIngredientId =
                ingredientsCollection.Find(i => i.Name == "Onion Powder").FirstOrDefault()?.IngredientId;
            /*20*/
            var msgIngredientId = ingredientsCollection.Find(i => i.Name == "MSG").FirstOrDefault()?.IngredientId;
            /*21*/
            var chickenBreastIngredientId = ingredientsCollection.Find(i => i.Name == "Chicken Breast").FirstOrDefault()
                ?.IngredientId;
            /*22*/
            var onionChoppedIngredientId = ingredientsCollection.Find(i => i.Name == "Onion chopped").FirstOrDefault()
                ?.IngredientId;
            /*23*/
            var tomatoPasteIngredientId =
                ingredientsCollection.Find(i => i.Name == "Tomato paste").FirstOrDefault()?.IngredientId;
            /*24*/
            var chilliPowderIngredientId = ingredientsCollection.Find(i => i.Name == "Chilli Powder").FirstOrDefault()
                ?.IngredientId;
            /*25*/
            var groundBeefIngredientId =
                ingredientsCollection.Find(i => i.Name == "Ground Beef").FirstOrDefault()?.IngredientId;
            /*26*/
            var canKidneyBeansRinsedAndDrainedIngredientId = ingredientsCollection
                .Find(i => i.Name == "Can kidney beans, rinsed and drained").FirstOrDefault()?.IngredientId;
            /*27*/
            var largeTortillasIngredientId = ingredientsCollection.Find(i => i.Name == "Large Tortillas")
                .FirstOrDefault()?.IngredientId;
            /*28*/
            var firtosIngredientId = ingredientsCollection.Find(i => i.Name == "Fritos").FirstOrDefault()?.IngredientId;
            /*29*/
            var shreddedCheddarIngredientId = ingredientsCollection.Find(i => i.Name == "Shredded c heddar")
                .FirstOrDefault()?.IngredientId;
            /*30*/
            var limeIngredientId = ingredientsCollection.Find(i => i.Name == "Lime").FirstOrDefault()?.IngredientId;
            /*31*/
            var groundCuminIngredientId =
                ingredientsCollection.Find(i => i.Name == "Ground cumin").FirstOrDefault()?.IngredientId;
            /*32*/
            var cayennePepperIngredientId = ingredientsCollection.Find(i => i.Name == "Cayenne pepper").FirstOrDefault()
                ?.IngredientId;
            /*33*/
            var flakyWhiteFishIngredientId = ingredientsCollection.Find(i => i.Name == "Flaky white fish")
                .FirstOrDefault()?.IngredientId;
            /*34*/
            var avocadoIngredientId =
                ingredientsCollection.Find(i => i.Name == "Avocado").FirstOrDefault()?.IngredientId;
            /*35*/
            var redPepperFlakesIngredientId =
                ingredientsCollection.Find(i => i.Name == "Red Pepper Flakes").FirstOrDefault()?.IngredientId;
            /*36*/
            var onionsIngredientId = ingredientsCollection.Find(i => i.Name == "Onions").FirstOrDefault()?.IngredientId;
            /*37*/
            var greenPepperIngredientId =
                ingredientsCollection.Find(i => i.Name == "Green Pepper").FirstOrDefault()?.IngredientId;
            /*38*/
            var redPepperIngredientId =
                ingredientsCollection.Find(i => i.Name == "Red Pepper").FirstOrDefault()?.IngredientId;
            /*39*/
            var pizzaDoughIngredientId =
                ingredientsCollection.Find(i => i.Name == "Pizza dough").FirstOrDefault()?.IngredientId;
            /*40*/
            var ketchupSauceIngredientId = ingredientsCollection.Find(i => i.Name == "Ketchup sauce").FirstOrDefault()
                ?.IngredientId;
            /*41*/
            var hotSauceIngredientId =
                ingredientsCollection.Find(i => i.Name == "Hot Sauce").FirstOrDefault()?.IngredientId;
            /*42*/
            var butterIngredientId = ingredientsCollection.Find(i => i.Name == "Butter").FirstOrDefault()?.IngredientId;
            /*43*/
            var heavyCreamIngredientId =
                ingredientsCollection.Find(i => i.Name == "Heavy Cream").FirstOrDefault()?.IngredientId;
            /*44*/
            var wholeMilkPlainYogurtIngredientId = ingredientsCollection.Find(i => i.Name == "Whole-milk plain yogurt")
                .FirstOrDefault()?.IngredientId;
            /*45*/
            var chesseIngredientId = ingredientsCollection.Find(i => i.Name == "Cheese").FirstOrDefault()?.IngredientId;
            /*46*/
            var mozzarellaIngredientId =
                ingredientsCollection.Find(i => i.Name == "Mozzarella").FirstOrDefault()?.IngredientId;
            /*47*/
            var celeryStalksIngredientId = ingredientsCollection.Find(i => i.Name == "Celery talks").FirstOrDefault()
                ?.IngredientId;
            /*48*/
            var parmesanChesseIngredientId = ingredientsCollection.Find(i => i.Name == "Parmesan Cheese")
                .FirstOrDefault()?.IngredientId;
            /*49*/
            var pancettaIngredientId =
                ingredientsCollection.Find(i => i.Name == "Panecetta").FirstOrDefault()?.IngredientId;
            /*50*/
            var spaghettiIngredientId =
                ingredientsCollection.Find(i => i.Name == "Spaghetti").FirstOrDefault()?.IngredientId;
            /*51*/
            var garlicIngredientId = ingredientsCollection.Find(i => i.Name == "Garlic").FirstOrDefault()?.IngredientId;
            /*52*/
            var lasagnaNoodlesIngredientId = ingredientsCollection.Find(i => i.Name == "Lasagna noodles")
                .FirstOrDefault()?.IngredientId;
            /*53*/
            var italianSauceIngredientId = ingredientsCollection.Find(i => i.Name == "Italian sauce").FirstOrDefault()
                ?.IngredientId;
            /*54*/
            var crushedTomatoesIngredientId = ingredientsCollection.Find(i => i.Name == "Crushed Tomatoes")
                .FirstOrDefault()?.IngredientId;
            /*55*/
            var sugarIngredientId = ingredientsCollection.Find(i => i.Name == "Sugar").FirstOrDefault()?.IngredientId;
            /*56*/
            var mincedFreshParsleyIngredientId = ingredientsCollection.Find(i => i.Name == "Minced fresh parsley")
                .FirstOrDefault()?.IngredientId;
            /*57*/
            var ricottaCheeseIngredientId = ingredientsCollection.Find(i => i.Name == "Ricotta cheese").FirstOrDefault()
                ?.IngredientId;
            /*58*/
            var fennelSeedIngredientId =
                ingredientsCollection.Find(i => i.Name == "Fennel seed").FirstOrDefault()?.IngredientId;
            /*59*/
            var bananaIngredientId = ingredientsCollection.Find(i => i.Name == "Banana").FirstOrDefault()?.IngredientId;
            /*60*/
            var frozenStrawberriesIngredientId = ingredientsCollection.Find(i => i.Name == "Frozen Strawberries")
                .FirstOrDefault()?.IngredientId;
            /*61*/
            var greekYogurtIngredientId =
                ingredientsCollection.Find(i => i.Name == "Greek Yogurt").FirstOrDefault()?.IngredientId;


            var Recette = new[]
            {
                new Recette
                {
                    Id_categorie = "3",
                    Title = "Oatmeal Cookies",
                    Photo_url =
                        "https://www.texanerin.com/content/uploads/2019/06/nobake-chocolate-cookies-1-650x975.jpg",
                    PhotosArray = new[]
                    {
                        "https://www.texanerin.com/content/uploads/2019/06/nobake-chocolate-cookies-1-650x975.jpg",
                        "https://namelymarly.com/wp-content/uploads/2018/04/20180415_Beet_Lasagna_10.jpg",
                        "https://advancelocal-adapter-image-uploads.s3.amazonaws.com/image.al.com/home/bama-media/width600/img/news_impact/photo/burger-fijpg-57e7e5907630c2ad.jpg",
                        "https://img.thedailybeast.com/image/upload/c_crop,d_placeholder_euli9k,h_1439,w_2560,x_0,y_0/dpr_1.5/c_limit,w_1044/fl_lossy,q_auto/v1492718105/articles/2013/09/24/burger-king-s-new-french-fries-took-ten-years-to-develop/130923-gross-burger-tease_izz59e",
                        "https://aht.seriouseats.com/images/2012/02/20120221-193971-fast-food-fries-Burger-King-fries-2.jpg"
                    },
                    Time = "15",
                    Ingredients = new List<Ingredients>
                    {
                        new Ingredients { IngredientId = oilIngredientId, Quantite = "200ml" },
                        new Ingredients { IngredientId = saltIngredientId, Quantite = "5g" },
                        new Ingredients { IngredientId = russetPotatoesIngredientId, Quantite = "300g" }
                    },
                    Description =
                        "-- Start with cleaned and peeled russet potatoes that you have cut into 3/8-inch match sticks. Place in bowl of very cold water: keep rinsing and changing the water until the water is clear; drain thoroughly and dry with paper towels or a clean lint-free kitchen towel.\n\n -- Meanwhile, you preheat your hot oil to 350 degrees F. Place prepared taters in oil and cook about 5 minutes. They will have that blond-tone color to them. \n\n -- Note: Once you add cold potatoes to the hot oil, the temperature of your oil is going to drop - you want it to be somewhere between 330 - 325 degrees F. \n\n -- Remove from oil; drain and cool. Now - either refrigerate until ready to finish cooking, or cool completely and freeze up to 3 months. To freeze properly - place completely cooled fries in single layer on tray and place in freezer until frozen. Then bag them.\n\n -- To finish cooking - preheat your oil to 400* F. Add your cold fries (which will drop the oil temp - which is fine because you want it near the 375 degrees F. temp) and cook a few minutes until done. Lightly salt them and shake well so that the salt distributes well and they are not salty."
                },
                // Ajouter les autres recettes ici
                new Recette
                {
                    Id_categorie = "4",
                    Title = "Triple Berry Smoothie",
                    Photo_url =
                        "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/delish-how-to-make-a-smoothie-horizontal-1542310071.png?crop=0.803xw:0.923xh;0.116xw,0.00510xh&resize=768:*",
                    PhotosArray = new[]
                    {
                        "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/delish-how-to-make-a-smoothie-horizontal-1542310071.png?crop=0.803xw:0.923xh;0.116xw,0.00510xh&resize=768:*",
                        "https://www.vitamix.com/media/other/images/xVitamix-Triple-Berry-Smoothie-square-crop__1.jpg.pagespeed.ic.OgTC3ILD3R.jpg",
                        "http://images.media-allrecipes.com/userphotos/960x960/3798204.jpg",
                        "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTrzui8MM6W66I29VZwVvcjpGv99JW3O1owgupc3KwB65rhAyrZ"
                    },
                    Time = "10",
                    Ingredients = new List<Ingredients>
                    {
                        new Ingredients { IngredientId = bananaIngredientId, Quantite = "1" },
                        new Ingredients { IngredientId = frozenStrawberriesIngredientId, Quantite = "1/2 lbs" },
                        new Ingredients { IngredientId = greekYogurtIngredientId, Quantite = "1/2 litters" }
                    },
                    Description =
                        "In a blender, combine all ingredients and blend until smooth. Then divide between 2 cups and top with blackberries, if desired."
                },
                new Recette
                {
                    Id_categorie = "3",
                    Title = "Vegan Cookies",
                    Photo_url =
                        "https://www.texanerin.com/content/uploads/2018/06/no-bake-lactation-cookies-1-650x975.jpg",
                    PhotosArray = new[]
                    {
                        "https://www.texanerin.com/content/uploads/2018/06/no-bake-lactation-cookies-1-650x975.jpg",
                        "https://ichef.bbci.co.uk/news/660/cpsprodpb/B2C0/production/_106106754_vegnuggets976.jpg",
                        "https://pixel.nymag.com/imgs/daily/grub/2017/11/22/22-mcds-chicken-tenders.w330.h330.jpg",
                        "https://imagesvc.meredithcorp.io/v3/mm/image?url=https%3A%2F%2Fcdn-img.health.com%2Fsites%2Fdefault%2Ffiles%2Fstyles%2Flarge_16_9%2Fpublic%2Fstyles%2Fmain%2Fpublic%2Fgettyimages-508510211.jpg%3Itok%3Dh-Uryi8r&w=400&c=sc&poi=face&q=85"
                    },
                    Time = "30",
                    Ingredients = new List<Ingredients>
                    {
                        new Ingredients { IngredientId = oilIngredientId, Name = "Oil", Quantite = "2 quarts" },
                        new Ingredients { IngredientId = eggsIngredientId, Quantite = "1" },
                        new Ingredients { IngredientId = allPurposeFlourIngredientId, Quantite = "1 cup" },
                        new Ingredients { IngredientId = waterIngredientId, Quantite = "1 cup" },
                        new Ingredients { IngredientId = onionPowderIngredientId, Quantite = "1 teaspon" },
                        new Ingredients { IngredientId = saltIngredientId, Quantite = "2 teaspons" },
                        new Ingredients { IngredientId = blackPepperIngredientId, Quantite = "1/4 teaspons" },
                        new Ingredients { IngredientId = garlicPowderIngredientId, Quantite = "1/8 teaspons" },
                        new Ingredients { IngredientId = msgIngredientId, Quantite = "1/2 teaspons" },
                        // new Ingredient  { IngredientId =           chickenBreastIngredientId ,  Quantite = "4"  }
                    },
                    Description =
                        "-- Beat the egg and then combine it with water in a bowl. Stir. Combine the flour, salt, MSG, pepper, onion powder and garlic powder in a gallon size zip lock bag. Pound each of the breast filets until about 1/4-inch thick. Then cut into bite sized pieces. Coat each piece with the flour mixture by shaking in the zip lock bag. Remove and coat in the egg mixture. Then coat in the flour mixture again. Shake to coat. Deep fry at 375 degrees for 10-12 minutes, until browned and crispy."
                },


                new Recette
                {
                    Id_categorie = "3",
                    Title = "Pumpkin Spice Cookies",
                    Photo_url = "https://www.texanerin.com/content/uploads/2018/11/pumpkin-spice-cookies-4-650x975.jpg",
                    PhotosArray = new[]
                    {
                        "https://www.texanerin.com/content/uploads/2018/11/pumpkin-spice-cookies-4-650x975.jpg",
                        "https://cdn.junglecreations.com/wp/junglecms/2018/07/4164c5bd-wide-thumbnail.jpg",
                        "https://pinchofyum.com/wp-content/uploads/Crunchwrap-Inside.jpg",
                        "https://monsonmadethis.com/wp-content/uploads/2017/10/IMG_20171015_161017_025-e1533869302263.jpg"
                    },
                    Time = "45",
                    Ingredients = new List<Ingredients>
                    {
                        new Ingredients { IngredientId = oilIngredientId, Quantite = "1" },
                        new Ingredients { IngredientId = onionChoppedIngredientId, Quantite = "1/2 lbs" },
                        new Ingredients { IngredientId = tomatoPasteIngredientId, Quantite = "1/2 litters" },
                        new Ingredients { IngredientId = garlicPowderIngredientId, Quantite = "1/2 litters" },
                        new Ingredients { IngredientId = paprikaIngredientId, Quantite = "1/2 litters" },
                        new Ingredients { IngredientId = chilliPowderIngredientId, Quantite = "1/2 litters" },
                        new Ingredients { IngredientId = groundBeefIngredientId, Quantite = "1/2 litters" },
                        new Ingredients { IngredientId = saltIngredientId, Quantite = "1/2 litters" },
                        new Ingredients { IngredientId = blackPepperIngredientId, Quantite = "1/2 litters" },
                        new Ingredients
                            { IngredientId = canKidneyBeansRinsedAndDrainedIngredientId, Quantite = "1/2 litters" },
                        new Ingredients { IngredientId = largeTortillasIngredientId, Quantite = "1/2 litters" },
                        new Ingredients { IngredientId = firtosIngredientId, Quantite = "1/2 litters" },
                        new Ingredients { IngredientId = shreddedCheddarIngredientId, Quantite = "1/2 litters" }
                    },
                    Description =
                        "-- In a medium pot over medium heat, heat 1 tablespoon oil. Add onion and cook until soft, 5 minutes. Add garlic and cook until fragrant, 1 minute more. Add tomato paste and stir to coat onion and garlic. Add ground beef and cook, breaking up meat with a wooden spoon, until no longer pink, 6 minutes. Drain fat.\n\n -- Return beef to pot and season with chili powder, paprika, salt, and pepper. Add tomato sauce and kidney beans. Bring to a boil, then reduce heat and let simmer 15 minutes. Add some chili to center of each tortilla, leaving room to fold in edges. Top with Fritos, then cheddar. Fold edges of tortillas toward the center, creating pleats. Invert Crunchwraps so pleats are on the bottom and stay together.\n\n -- In medium skillet over medium heat, heat remaining tablespoon oil. Add a Crunchwrap seam side down and cook until tortilla is golden, 3 to 5 minutes per side. Repeat with remaining Crunchwraps"
                },
                new Recette
                {
                    Id_categorie = "3",
                    Title = "Brownies",
                    Photo_url =
                        "https://www.texanerin.com/content/uploads/2018/01/coconut-flour-brownies-1-650x975.jpg",
                    PhotosArray = new[]
                    {
                        "https://www.texanerin.com/content/uploads/2018/01/coconut-flour-brownies-1-650x975.jpg",
                        "https://images-gmi-pmc.edge-generalmills.com/6fbc6859-e2b1-499d-b0fa-ada600c9cc3f.jpg",
                        "http://www.recipe4living.com/assets/itemimages/400/400/3/83c29ac7418067c2e74f31c8abdd5a43_477607049.jpg",
                        "https://www.franchisechatter.com/wp-content/uploads/2014/08/KFC-Photo-by-James.jpg"
                    },
                    Time = "30",
                    Ingredients = new List<Ingredients>
                    {
                        new Ingredients { IngredientId = oilIngredientId, Quantite = "1" },
                        new Ingredients { IngredientId = onionChoppedIngredientId, Quantite = "1/2 lbs" },
                        new Ingredients { IngredientId = tomatoPasteIngredientId, Quantite = "1/2 litters" },
                        new Ingredients { IngredientId = garlicPowderIngredientId, Quantite = "1/2 litters" },
                        new Ingredients { IngredientId = paprikaIngredientId, Quantite = "1/2 litters" },
                        new Ingredients { IngredientId = chilliPowderIngredientId, Quantite = "1/2 litters" },
                        new Ingredients { IngredientId = groundBeefIngredientId, Quantite = "1/2 litters" },
                        new Ingredients { IngredientId = saltIngredientId, Quantite = "1/2 litters" },
                        new Ingredients { IngredientId = blackPepperIngredientId, Quantite = "1/2 litters" },
                        new Ingredients
                            { IngredientId = canKidneyBeansRinsedAndDrainedIngredientId, Quantite = "1/2 litters" },
                        new Ingredients { IngredientId = largeTortillasIngredientId, Quantite = "1/2 litters" },
                        new Ingredients { IngredientId = firtosIngredientId, Quantite = "1/2 litters" },
                        new Ingredients { IngredientId = shreddedCheddarIngredientId, Quantite = "1/2 litters" },
                        new Ingredients { IngredientId = shreddedCheddarIngredientId, Quantite = "1/2 litters" },
                        new Ingredients { IngredientId = shreddedCheddarIngredientId, Quantite = "1/2 litters" },
                        new Ingredients { IngredientId = shreddedCheddarIngredientId, Quantite = "1/2 litters" }
                    },
                    Description =
                        "-- Preheat fryer to 350°F. Thoroughly mix together all spices. Combine spices with flour, brown sugar and salt. Dip chicken pieces in egg white to lightly coat them, then transfer to flour mixture. Turn a few times and make sure the flour mix is really stuck to the chicken.\n\n -- Repeat with all the chicken pieces. Let chicken pieces rest for 5 minutes so crust has a chance to dry a bit. Fry chicken in batches. Breasts and wings should take 12-14 minutes, and legs and thighs will need a few more minutes. Chicken pieces are done when a meat thermometer inserted into the thickest part reads 165°F. Let chicken drain on a few paper towels when it comes out of the fryer. Serve hot."
                },
                new Recette
                {
                    Id_categorie = "1",
                    Title = "Perfect Fish Tacos",
                    Photo_url = "https://hips.hearstapps.com/hmg-prod/images/190307-fish-tacos-112-1553283299.jpg",
                    PhotosArray = new[]
                    {
                        "http://d2814mmsvlryp1.cloudfront.net/wp-content/uploads/2014/04/WGC-Fish-Tacos-copy-2.jpg",
                        "https://thecozyapron.com/wp-content/uploads/2018/03/baja-fish-tacos_thecozyapron_1.jpg",
                        "https://www.simplyrecipes.com/wp-content/uploads/2017/06/2017-07-22-FishTacos-6.jpg"
                    },
                    Time = "35",
                    Ingredients = new List<Ingredients>
                    {
                        new Ingredients { IngredientId = oilIngredientId, Quantite = "1" },
                        new Ingredients { IngredientId = onionChoppedIngredientId, Quantite = "1/2 lbs" },
                        new Ingredients { IngredientId = tomatoPasteIngredientId, Quantite = "1/2 litters" },
                        new Ingredients { IngredientId = garlicPowderIngredientId, Quantite = "1/2 litters" },
                        new Ingredients { IngredientId = paprikaIngredientId, Quantite = "1/2 litters" },
                        new Ingredients { IngredientId = chilliPowderIngredientId, Quantite = "1/2 litters" },
                        new Ingredients { IngredientId = groundBeefIngredientId, Quantite = "1/2 litters" },
                        new Ingredients { IngredientId = saltIngredientId, Quantite = "1/2 litters" },
                        new Ingredients { IngredientId = blackPepperIngredientId, Quantite = "1/2 litters" },
                        new Ingredients
                            { IngredientId = canKidneyBeansRinsedAndDrainedIngredientId, Quantite = "1/2 litters" },
                        new Ingredients { IngredientId = largeTortillasIngredientId, Quantite = "1/2 litters" },
                    },
                    Description =
                        "-- In a medium shallow bowl, whisk together olive oil, lime juice, paprika, chili powder, cumin, and cayenne. Add cod, tossing until evenly coated. Let marinate 15 minutes. Meanwhile, make slaw: In a large bowl, whisk together mayonnaise, lime juice, cilantro, and honey. Stir in cabbage, corn, and jalapeño. Season with salt and pepper.\n\n -- In a large nonstick skillet over medium-high heat, heat vegetable oil. Remove cod from marinade and season both sides of each filet with salt and pepper. Add fish flesh side-down. Cook until opaque and cooked through, 3 to 5 minutes per side.\n\n -- Let rest 5 minutes before flaking with a fork. Assemble tacos: Serve fish over grilled tortillas with corn slaw and avocado. Squeeze lime juice on top and garnish with sour cream. "
                },
                new Recette
                {
                    Id_categorie = "1",
                    Title = "Chicken Fajitas",
                    Photo_url =
                        "https://tmbidigitalassetsazure.blob.core.windows.net/secure/RMS/attachments/37/1200x1200/Flavorful-Chicken-Fajitas_EXPS_GHBZ18_12540_B08_15_8b.jpg",
                    PhotosArray = new[]
                    {
                        "https://dadwithapan.com/wp-content/uploads/2015/07/Spicy-Chicken-Fajitas-22-1200x480.jpg",
                        "https://3.bp.blogspot.com/-X-dHj7ORF9Q/XH4ssgTuSZI/AAAAAAAAEig/E46HP9wCfdsvyJFcMTX30cw-ICep8lF9ACHMYCw/s1600/chicken-fajitas-mexican-food-id-149559-buzzerg.jpg",
                        "https://cdn-image.foodandwine.com/sites/default/files/styles/medium_2x/public/201403-xl-chipotle-chicken-fajitas.jpg?itok=ghVcI5SQ"
                    },
                    Time = "35",
                    Ingredients = new List<Ingredients>
                    {
                        new Ingredients { IngredientId = driedOreganoIngredientId, Quantite = "1/2 teaspoons" },
                        new Ingredients { IngredientId = oilIngredientId, Quantite = "4 teaspoons" },
                        new Ingredients { IngredientId = saltIngredientId, Quantite = "1/2 teaspoons" },
                        new Ingredients { IngredientId = limeIngredientId, Quantite = "2 teaspoons" },
                        new Ingredients { IngredientId = groundCuminIngredientId, Quantite = "1 teaspoon" },
                        new Ingredients { IngredientId = garlicPowderIngredientId, Quantite = "1 teaspoon" },
                        new Ingredients { IngredientId = chilliPowderIngredientId, Quantite = "1/2 teaspoons" },
                        new Ingredients { IngredientId = paprikaIngredientId, Quantite = "1/2 teaspoons" },
                        new Ingredients { IngredientId = chickenBreastIngredientId, Quantite = "1 pound" },
                        new Ingredients { IngredientId = onionChoppedIngredientId, Quantite = "1/2 cup" },
                        new Ingredients { IngredientId = largeTortillasIngredientId, Quantite = "6" },
                        new Ingredients { IngredientId = onionsIngredientId, Quantite = "4" },
                        new Ingredients { IngredientId = greenPepperIngredientId, Quantite = "1/2" },
                        new Ingredients { IngredientId = redPepperIngredientId, Quantite = "1/2" },
                    },
                    Description =
                        "-- In a large bowl, combine 2 tablespoons oil, lemon juice and seasonings; add the chicken. Turn to coat; cover. Refrigerate for 1-4 hours In a large skillet, saute peppers and onions in remaining oil until crisp-tender. Remove and keep warm. Drain chicken, discarding marinade. In the same skillet, cook chicken over medium-high heat for 5-6 minutes or until no longer pink.\n\n -- Return pepper mixture to pan; heat through. Spoon filling down the center of tortillas; fold in half. Serve with toppings as desired."
                },
                new Recette
                {
                    Id_categorie = "2",
                    Title = "Buffalo Pizza",
                    Photo_url =
                        "https://images.unsplash.com/photo-1513104890138-7c749659a591?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&w=1000&q=80",
                    PhotosArray = new[]
                    {
                        "https://www.tablefortwoblog.com/wp-content/uploads/2019/01/buffalo-chicken-pizza-recipe-photos-tablefortwoblog-3-500x500.jpg",
                        "http://pizzachoicema.com/wp-content/uploads/2018/08/Buffalo-Chicken-Pizza.jpg",
                        "https://static1.squarespace.com/static/565bb41ae4b0509ba9fdf769/t/5b9a8e80aa4a998b0be0fcf4/1536855690622/pizza.gif"
                    },
                    Time = "50",
                    Ingredients = new List<Ingredients>
                    {
                        new Ingredients { IngredientId = pizzaDoughIngredientId, Quantite = "1 lb" },
                        new Ingredients { IngredientId = ketchupSauceIngredientId, Quantite = "1 cup" },
                        new Ingredients { IngredientId = hotSauceIngredientId, Quantite = "1/2 cup" },
                        new Ingredients { IngredientId = butterIngredientId, Quantite = "1/4 cup" },
                        new Ingredients { IngredientId = heavyCreamIngredientId, Quantite = "2 tablespoons" },
                        new Ingredients { IngredientId = wholeMilkPlainYogurtIngredientId, Quantite = "1/2 cup" },
                        new Ingredients { IngredientId = garlicPowderIngredientId, Quantite = "1/4 teaspoons" },
                        new Ingredients { IngredientId = celerySaltIngredientId, Quantite = "1/4 teaspoons" },
                        new Ingredients { IngredientId = limeIngredientId, Quantite = "1/4 teaspoons" },
                        new Ingredients { IngredientId = chesseIngredientId, Quantite = "2 oz" },
                        new Ingredients { IngredientId = allPurposeFlourIngredientId, Quantite = "for dusting" },
                        new Ingredients { IngredientId = blackPepperIngredientId, Quantite = "1/2 teaspoons" },
                        new Ingredients { IngredientId = redPepperIngredientId, Quantite = "2" },
                        new Ingredients { IngredientId = mozzarellaIngredientId, Quantite = "9 oz" },
                    },

                    Description =
                        "-- Place a rack in upper third of oven. Place a large cast-iron skillet on rack and preheat oven to 500° (or as high as your oven will go). Place pizza dough in a large bowl, pour a little oil over, and turn to coat. Cover bowl with plastic and let dough proof at room temperature while pan and oven heat up.\n\n -- Meanwhile, cook hot sauce, marinara sauce, and butter in a medium saucepan over medium heat, stirring occasionally, until butter is melted. Stir in cream, reduce heat to low, and simmer, stirring occasionally, until slightly thickened and warmed through, about 10 minutes. Heat 1 Tbsp. oil in a large skillet over medium-high. Add chicken, toss to coat, then add ¼ cup Buffalo sauce.\n\n -- Cook chicken, tossing occasionally, until heated through, about 2 minutes. Reduce heat and simmer, stirring often, until chicken is well coated and sauce is slightly thickened, about 5 minutes. Meanwhile, whisk yogurt, lemon juice, celery salt, garlic powder, ¼ cup blue cheese, ½ tsp. pepper, and 2 Tbsp. water in a small bowl, adding more water if sauce seems too thick (it should be pourable); set aside.\n\n -- Turn out dough onto a lightly floured work surface. Shape with your hands into a round that’s slightly larger than the cast-iron skillet you’re using. Take hot skillet out of oven (watch that handle!) and place on a heatproof surface. Add a little flour to pan. Lay dough in skillet, then work edges of dough up sides of skillet with your fingertips (use a rubber spatula or wooden spoon if you’re nervous about touching the hot pan). Drizzle a little oil around inside edge of pan so that it trickles behind and underneath dough, which will encourage browning and help it release.\n\n -- Spread about ⅓ cup Buffalo sauce over dough. Arrange mozzarella over, then top with remaining ¼ cup blue cheese. Arrange chicken mixture on top. Bake pizza on top rack until crust and cheese are nicely browned, 15–20 minutes. Transfer skillet to stovetop (again, watch that handle!) and let pizza rest a few minutes. Using a spatula, slide pizza onto a cutting board or platter. Arrange celery over, then top with reserved blue cheese dressing. Season with pepper, then drizzle with oil."
                },
                new Recette
                {
                    Id_categorie = "0",
                    Title = "Classic Lasagna",
                    Photo_url = "https://namelymarly.com/wp-content/uploads/2018/04/20180415_Beet_Lasagna_10.jpg",
                    PhotosArray = new[]
                    {
                        "https://namelymarly.com/wp-content/uploads/2018/04/20180415_Beet_Lasagna_10.jpg",
                        "https://advancelocal-adapter-image-uploads.s3.amazonaws.com/image.al.com/home/bama-media/width600/img/news_impact/photo/burger-fijpg-57e7e5907630c2ad.jpg",
                        "https://img.thedailybeast.com/image/upload/c_crop,d_placeholder_euli9k,h_1439,w_2560,x_0,y_0/dpr_1.5/c_limit,w_1044/fl_lossy,q_auto/v1492718105/articles/2013/09/24/burger-king-s-new-french-fries-took-ten-years-to-develop/130923-gross-burger-tease_izz59e",
                        "https://aht.seriouseats.com/images/2012/02/20120221-193971-fast-food-fries-Burger-King-fries-2.jpg"
                    },
                    Time = "15",
                    Ingredients = new List<Ingredients>
                    {
                        new Ingredients { IngredientId = oilIngredientId, Quantite = "200ml" },
                        new Ingredients { IngredientId = saltIngredientId, Quantite = "5g" },
                        new Ingredients { IngredientId = russetPotatoesIngredientId, Quantite = "300g" },
                    },

                    Description =
                        "-- Start with cleaned and peeled russet potatoes that you have cut into 3/8-inch match sticks. Place in bowl of very cold water: keep rinsing and changing the water until the water is clear; drain thoroughly and dry with paper towels or a clean lint-free kitchen towel.\n\n -- Meanwhile, you preheat your hot oil to 350 degrees F. Place prepared taters in oil and cook about 5 minutes. They will have that blond-tone color to them. \n\n -- Note: Once you add cold potatoes to the hot oil, the temperature of your oil is going to drop - you want it to be somewhere between 330 - 325 degrees F. \n\n -- Remove from oil; drain and cool. Now - either refrigerate until ready to finish cooking, or cool completely and freeze up to 3 months. To freeze properly - place completely cooled fries in single layer on tray and place in freezer until frozen. Then bag them.\n\n -- To finish cooking - preheat your oil to 400* F. Add your cold fries (which will drop the oil temp - which is fine because you want it near the 375 degrees F. temp) and cook a few minutes until done. Lightly salt them and shake well so that the salt distributes well and they are not salty."
                },
                new Recette
                {
                    Id_categorie = "2",
                    Title = "Spaghetti Carbonara",
                    Photo_url = "https://truffle-assets.imgix.net/655ce202-862-butternutsquashcarbonara-land.jpg",
                    PhotosArray = new[]
                    {
                        "https://ak3.picdn.net/shutterstock/videos/10431533/thumb/10.jpg",
                        "https://www.kcet.org/sites/kl/files/styles/kl_image_large/public/thumbnails/image/square_hero_desktop_2x_sfs_spaghetti_carbonara_clr-3.jpg?itok=T-rsBDIZ",
                        "https://cdn-image.foodandwine.com/sites/default/files/HD-201104-r-spaghetti-with-anchovy.jpg"
                    },
                    Time = "15",
                    Ingredients = new List<Ingredients>
                    {
                        new Ingredients { IngredientId = parmesanChesseIngredientId, Quantite = "50g" },
                        new Ingredients { IngredientId = pancettaIngredientId, Quantite = "100g" },
                        new Ingredients { IngredientId = spaghettiIngredientId, Quantite = "350g" },
                        new Ingredients { IngredientId = garlicIngredientId, Quantite = "2 plump" },
                        new Ingredients { IngredientId = butterIngredientId, Quantite = "50g" },
                        new Ingredients { IngredientId = eggsIngredientId, Quantite = "3" },
                        new Ingredients { IngredientId = saltIngredientId, Quantite = "2 teaspoons" },
                        new Ingredients { IngredientId = blackPepperIngredientId, Quantite = "2 teaspoons" },
                    },

                    Description =
                        "-- Mettez les jaunes d'œufs dans un bol, râpez finement le Parmesan, assaisonnez de poivre, puis mélangez bien avec une fourchette et mettez de côté. Coupez toute peau dure de la pancetta et mettez de côté, puis hachez la viande. Faites cuire les spaghettis dans une grande casserole d'eau bouillante salée jusqu'à ce qu'ils soient al dente.\n\n -- Pendant ce temps, frottez la peau de pancetta, si vous en avez, sur toute la base d'une poêle moyenne (cela ajoutera une saveur fantastique, ou utilisez 1 cuillère à soupe d'huile à la place), puis placez sur feu moyen-élevé. Pelez l'ail, puis écrasez-le avec la paume de votre main, ajoutez-le à la poêle et laissez-le parfumer la graisse pendant 1 minute. Ajoutez la pancetta, puis faites cuire pendant 4 minutes, ou jusqu'à ce qu'elle commence à croustiller. Retirez l'ail de la poêle et jetez-le, puis, en réservant un peu d'eau de cuisson, égouttez et ajoutez les spaghettis.\n\n -- Mélangez bien sur le feu pour qu'il absorbe vraiment toute cette belle saveur, puis retirez la poêle du feu. Ajoutez une louchée d'eau de cuisson et mélangez bien, assaisonnez de poivre, puis versez le mélange d'œufs - la poêle aidera à cuire doucement l'œuf, plutôt que de le brouiller. Mélangez bien, en ajoutant plus d'eau de cuisson jusqu'à ce qu'il soit bien brillant. Servez avec un peu de Parmesan râpé et une touche supplémentaire de poivre."
                },
                new Recette
                {
                    Id_categorie = "2",
                    Title = "Lazania",
                    Photo_url = "https://images8.alphacoders.com/817/817353.jpg",
                    PhotosArray = new[]
                    {
                        "https://previews.123rf.com/images/somegirl/somegirl1509/somegirl150900048/46103208-top-view-of-a-delicious-traditional-italian-lasagna-made-with-minced-beef-bolognese-sauce-topped-wit.jpg",
                        "https://truffle-assets.imgix.net/87f324e4-YOUTUBE-NO-TXT.00_03_19_14.Imagen_fija001.jpg",
                        "https://images4.alphacoders.com/817/817350.jpg"
                    },
                    Time = "60",
                    Ingredients = new List<Ingredients>
                    {
                        new Ingredients { IngredientId = onionsIngredientId, Quantite = "1 large" },
                        new Ingredients { IngredientId = groundBeefIngredientId, Quantite = "1 pound" },
                        new Ingredients { IngredientId = garlicIngredientId, Quantite = "5 cloves" },
                        new Ingredients { IngredientId = lasagnaNoodlesIngredientId, Quantite = "1 pound" },
                        new Ingredients { IngredientId = italianSauceIngredientId, Quantite = "1 pound" },
                        new Ingredients { IngredientId = crushedTomatoesIngredientId, Quantite = "1 28 ounce can" },
                        new Ingredients { IngredientId = tomatoPasteIngredientId, Quantite = "2 6 ounce can" },
                        new Ingredients { IngredientId = sugarIngredientId, Quantite = "2 tablespoons" },
                        new Ingredients { IngredientId = mincedFreshParsleyIngredientId, Quantite = "1/4 cup" },
                        new Ingredients { IngredientId = driedBasilIngredientId, Quantite = "1/2 cup" },
                        new Ingredients { IngredientId = saltIngredientId, Quantite = "1/2 teaspoons" },
                        new Ingredients { IngredientId = fennelSeedIngredientId, Quantite = "1 teaspoon" },
                        new Ingredients { IngredientId = blackPepperIngredientId, Quantite = "1/4 teaspoons" },
                        new Ingredients { IngredientId = eggsIngredientId, Quantite = "1 large" },
                        new Ingredients { IngredientId = mozzarellaIngredientId, Quantite = "1 pound" },
                        new Ingredients { IngredientId = parmesanChesseIngredientId, Quantite = "1 cup" },
                        new Ingredients { IngredientId = ricottaCheeseIngredientId, Quantite = "30 ounces" },
                    },

                    Description =
                        "-- Cuisez les nouilles selon les indications de l'emballage ; égouttez. Pendant ce temps, dans une cocotte, faites cuire la saucisse, la viande et l'oignon à feu moyen pendant 8 à 10 minutes ou jusqu'à ce que la viande ne soit plus rose, en émiettant la viande en morceaux. Ajoutez l'ail ; faites cuire 1 minute. Égouttez. Ajoutez les tomates, la pâte de tomate, l'eau, le sucre, 3 cuillères à soupe de persil, le basilic, le fenouil, 1/2 cuillère à café de sel et de poivre ; portez à ébullition. Réduisez le feu ; laissez mijoter à découvert pendant 30 minutes, en remuant de temps en temps. Dans un petit bol, mélangez l'œuf, le fromage ricotta, et le reste du persil et du sel. Préchauffez le four à 375 °F. Étalez 2 tasses de sauce à la viande dans un plat de cuisson non graissé de 13x9 pouces. Superposez avec 3 nouilles et un tiers du mélange de ricotta. Saupoudrez de 1 tasse de fromage mozzarella et de 2 cuillères à soupe de fromage Parmesan.\n\n -- Répétez les couches deux fois. Garnissez du reste de la sauce à la viande et des fromages (le plat sera plein). Cuisez au four, couvert, 25 minutes. Cuisez au four, à découvert, 25 minutes de plus ou jusqu'à ce que ce soit bouillonnant. Laissez reposer 15 minutes avant de servir."
                },
            };
            var recipesCollection = database.GetCollection<Recette>("Recette");
            recipesCollection.InsertMany(Recette);
        }
    }
}