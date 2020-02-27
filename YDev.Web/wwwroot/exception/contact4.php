<?php
    session_start();
    include("php/captcha.php");
    $_SESSION['captcha'] = simple_php_captcha();
?>
<!DOCTYPE html>
<html>
	<head>
		<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
		<title>EXCEPTION – Responsive Business HTML Template</title>
		<meta name="description" content="EXCEPTION – Responsive Business HTML Template">
		<meta name="author" content="EXCEPTION">
		
		<!-- Mobile Meta -->
		<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">
		
		<!-- Put favicon.ico and apple-touch-icon(s).png in the images folder -->
	    <link rel="shortcut icon" href="images/favicon.ico">
		    	
		<!-- CSS StyleSheets -->
		<link rel="stylesheet" href="http://fonts.googleapis.com/css?family=Open+Sans:400,300,700,800&amp;amp;subset=latin,latin-ext">
		<link rel="stylesheet" href="css/font-awesome.min.css">
		<link rel="stylesheet" href="css/animate.css">
		<link rel="stylesheet" href="css/prettyPhoto.css">
		<link rel="stylesheet" href="css/slick.css">
		<link rel="stylesheet" href="rs-plugin/css/settings.css">
		<link rel="stylesheet" id="MainStyle" href="css/style.css">
		<link rel="stylesheet" href="css/responsive.css">
		<!--[if lt IE 9]>
	    	<link rel="stylesheet" href="css/ie.css">
	    	<script type="text/javascript" src="js/html5.js"></script>
	    <![endif]-->

		
		<!-- Skin style (** you can change the link below with the one you need from skins folder in the css folder **) -->
		<link rel="stylesheet" id="skinCSS" href="css/skins/default.css">
	
	</head>
	<body>
	    
	    <!-- site preloader start -->
	    <div class="page-loader">
	    	<div class="loader-in"></div>
	    </div>
	    <!-- site preloader end -->
	    
	    <div class="pageWrapper">
		    
		    <!-- login box start -->
			<div class="login-box">
				<a class="close-login" href="#"><i class="fa fa-times"></i></a>
				<form>
					<div class="container">
						<p>Hello our valued visitor, We present you the best web solutions and high quality graphic designs with a lot of features. just login to your account and enjoy ...</p>
						<div class="login-controls">
							<div class="skew-25 input-box left">
								<input type="text" class="txt-box skew25" placeholder="User name Or Email" />
							</div>
							<div class="skew-25 input-box left">
								<input type="password" class="txt-box skew25" placeholder="Password" />
							</div>
							<div class="left skew-25 main-bg">
								<input type="submit" class="btn skew25" value="Login" />
							</div>
							<div class="check-box-box">
								<input type="checkbox" class="check-box" /><label>Remember me !</label>
								<a href="#">Forgot your password ?</a>
							</div>
						</div>
					</div>
				</form>
			</div>
			<!-- login box End -->
			
			
			<!-- Header Start -->
			<div id="headWrapper" class="clearfix">
		    	
		    	<!-- top bar start -->
		    	<div class="top-bar">
				    <div class="container">
						<div class="row">
							<div class="cell-5">
							    <ul>
								    <li><a href="#"><i class="fa fa-envelope"></i>info@it-rays.com</a></li>
								    <li><span><i class="fa fa-phone"></i> Call Us: +1 (888) 000-0000</span></li>
							    </ul>
							</div>
							<div class="cell-7 right-bar">
					    		<ul class="right">
						    	    <li><a href="cart.html"><i class="fa fa-shopping-cart"></i>0 item(s) - $0.00</a></li>
						    	    <li><a href="siteMap.html"><i class="fa fa-sitemap"></i>Site Map</a></li>
						    	    <li><a href="register.html"><i class="fa fa-user"></i>Register</a></li>
						    	    <li><a href="#" class="login-btn"><i class="fa fa-unlock-alt"></i> Login</a></li>
						        </ul>
							</div>
						</div>
				    </div>
			    </div>
			    <!-- top bar end -->
			    
			    <header class="top-head" data-sticky="true">
				    <div class="container">
					    <div class="row">
					    	<div class="logo cell-3">
						    	<a href="home.html"></a>
						    </div>
						    <div class="cell-9 top-menu">
							    <!-- top navigation menu start -->
							    <nav class="top-nav">
								    <ul>
								      <li><a href="#"><i class="fa fa-home"></i><span>Home</span></a>
									      <ul>
										      <li><a href="home.html">home 1</a></li>
										      <li><a href="home2.html">home 2</a></li>
										      <li><a href="home3.html">home 3</a></li>
										      <li><a href="home4.html">home 4</a></li>
										      <li><a href="home5.html">home 5</a></li>
										      <li><a href="homenews.html">home news</a></li>
										      <li><a href="#">Navigation</a>
										      		<ul>
										      			<li><a href="nav-2.html">Navigation 2</a></li>
										      			<li><a href="nav-3.html">Navigation 3</a></li>
										      			<li><a href="nav-4.html">Navigation 4</a></li>
										      			<li><a href="mega-menu.html">Mega Menu</a></li>
										      			<li><a href="nav-sticky.html">Sticky Navigation</a></li>
										      		</ul>
										      </li>
										      <li><a href="#">Headers</a>
										      		<ul>
										      			<li><a href="header2.html">Header 2</a></li>
										      			<li><a href="header3.html">Header 3</a></li>
										      			<li><a href="header4.html">Header 4</a></li>
										      			<li><a href="header5.html">Header 5</a></li>
										      			<li><a href="header6.html">Header 6</a></li>
										      			<li><a href="header7.html">Header 7</a></li>
										      		</ul>
										      </li>
                                            <li>
                                                <a href="#">Footers</a>
                                                <ul>
                                                    <li><a href="footer2.html">Footer 2</a></li>
                                                    <li><a href="footer3.html">Footer 3</a></li>
                                                    <li><a href="footer4.html">Footer 4</a></li>
                                                </ul>
                                            </li>
									      </ul>
								      </li>
								      <li><a href="#"><i class="fa fa-gift"></i><span>Portfolio</span></a>
								      		<ul>
										      <li><a href="portfolio-2-cols.html">Portfolio 2 columns</a></li>
										      <li><a href="portfolio-3-cols.html">Portfolio 3 columns</a></li>
										      <li><a href="portfolio-4-cols.html">Portfolio 4 columns</a></li>
										      <li><a href="portfolio-full.html">Portfolio full</a></li>
										      <li><a href="portfolio-single.html">Portfolio single</a></li>
										      <li><a href="portfolio-single2.html">Portfolio single 2</a></li>
									      </ul>
								      </li>
								      <li><a href="#"><i class="fa fa-copy"></i><span>Pages</span></a>
								      		<ul>
										      <li><a href="about-us.html">About us</a></li>
										      <li><a href="about-me.html">About me</a></li>
										      <li><a href="FAQ.html">FAQ</a></li>
										      <li><a href="find-job.html">Find a job</a></li>
										      <li><a href="pricing.html">Pricing</a></li>
										      <li><a href="services.html">Services</a></li>
										      <li><a href="#">Meet the team</a>
										      	<ul>
										      		<li><a href="team.html">Meet the team Style 1</a></li>
										      		<li><a href="team2.html">Meet the team Style 2</a></li>
										      	</ul>
										      </li>
										      <li><a href="page-full.html">Page Full width</a></li>
										      <li><a href="page-sidebar.html">Page with Sidebar</a></li>
										      <li><a href="page-left-bar.html">Page with Left Sidebar</a></li>
										      <li><a href="404.html">404 Page not found</a></li>
										      <li><a href="coming-soon.html">Coming Soon</a></li>
									      </ul>
								      </li>
								      <li><a href="#"><i class="fa fa-suitcase"></i><span>Shop</span></a>
								      		<ul>
								      			<li><a href="#">Shop Products listing</a>
							      					<ul>
							      						<li><a href="shop-right-bar.html">Right Side Bar</a></li>
							      						<li><a href="shop.html">Left Side Bar</a></li>
							      						<li><a href="shop-no-bar.html">No side bar</a></li>
							      					</ul>
								      			</li>
								      			<li><a href="#">Product Page</a>
								      				<ul>
							      						<li><a href="product-right-bar.html">Right Side Bar</a></li>
							      						<li><a href="product.html">Left Side Bar</a></li>
							      						<li><a href="product-no-bar.html">No side bar</a></li>
							      					</ul>
								      			</li>
								      			<li><a href="cart.html">Shoping cart</a></li>
								      			<li><a href="check-out.html">Check out</a></li>
								      		</ul>
								      </li>
								      <li><a href="#"><i class="fa fa-book"></i><span>Blog</span></a>
								      		<ul>
										      <li><a href="#">Blog Large Image</a>
										      		<ul>
										      			<li><a href="blog.html">Right Side Bar</a></li>
										      			<li><a href="blog-left-bar.html">Left Side Bar</a></li>
										      			<li><a href="blog-no-bar.html">No side bar</a></li>
										      		</ul>
										      </li>
										      <li><a href="#">Blog Small Image</a>
										      		<ul>
										      			<li><a href="blog-thumbnails.html">Right Side Bar</a></li>
										      			<li><a href="blog-thumbnails-left-bar.html">Left Side Bar</a></li>
										      			<li><a href="blog-thumbnails-no-bar.html">No side bar</a></li>
										      		</ul>
										      </li>
										      <li><a href="#">Blog masonry</a>
										      		<ul>
										      			<li><a href="blog-masonry.html">Right Side Bar</a></li>
										      			<li><a href="blog-masonry-left-bar.html">Left Side Bar</a></li>
										      			<li><a href="blog-masonry-no-bar.html">No side bar</a></li>
										      		</ul>
										      </li>
										      <li><a href="#">Blog Single</a>
										      		<ul>
										      			<li><a href="blog-single.html">Right Side Bar</a></li>
										      			<li><a href="blog-single-left-bar.html">Left Side Bar</a></li>
										      			<li><a href="blog-single-no-bar.html">No side bar</a></li>
										      		</ul>
										      </li>
										      
									      </ul>
								      </li>
								      <li><a href="#"><i class="fa fa-leaf"></i><span>Elements</span></a>
								      		<ul>
										      <li><a href="columns.html">Columns</a></li>
										      <li><a href="elements.html">Page Elements</a></li>
										      <li><a href="#">Page Title</a>
										      	<ul>
										      		<li><a href="page-title.html">Page Title 1</a></li>
										      		<li><a href="page-title2.html">Page Title 2</a></li>
										      		<li><a href="page-title3.html">Page Title 3</a></li>
										      		<li><a href="page-title4.html">Page Title 4</a></li>
										      	</ul>
										      </li>
										      <li><a href="typography.html">Typography</a></li>
										      <li><a href="font-icons.html">Icons</a></li>
									      </ul>
								      </li>
								      <li class="selected"><a href="#"><i class="fa fa-phone"></i><span>Contact</span></a>
								      	<ul>
                                              <li><a href="contact.html">Contact 1</a></li>
                                              <li><a href="contact.php">Contact 1 + PHP Captcha</a></li>
                                              <li><a href="contact2.html">Contact 2</a></li>
                                              <li><a href="contact2.php">Contact 2 + PHP Captcha</a></li>
                                              <li><a href="contact3.html">Contact 3</a></li>
                                              <li><a href="contact3.php">Contact 3 + PHP Captcha</a></li>
                                              <li><a href="contact4.html">Contact 4</a></li>
                                              <li class="selected"><a href="contact4.php">Contact 4 + PHP Captcha</a></li>
                                          </ul>
								      </li>
								    </ul>
							    </nav>
							    <!-- top navigation menu end -->
							    
							    <!-- top search start -->
							    <div class="top-search">
						    		<a href="#"><span class="fa fa-search"></span></a>
							    	<div class="search-box">
							    		<div class="input-box left">
							    			<input type="text" name="t" id="t-search" class="txt-box" placeHolder="Enter search keyword here..." />
							    		</div>
							    		<div class="left">
							    			<input type="submit" id="b-search" class="btn main-bg" value="GO" />
							    		</div>
							    	</div>
							    </div>
							    <!-- top search end -->

							</div>
					    </div>
				    </div>
			    </header>
			</div>
			<!-- Header End -->
			
			<!-- Content Start -->
			<div id="contentWrapper">
				<div class="page-title title-1">
					<div class="container">
						<div class="row">
							<div class="cell-12">
								<h1 class="fx" data-animate="fadeInLeft">Contact <span>us</span></h1>
								<div class="breadcrumbs main-bg fx" data-animate="fadeInUp">
									<span class="bold">You Are In:</span><a href="#">Home</a><span class="line-separate">/</span><a href="#">Pages </a><span class="line-separate">/</span><span>Contact us</span>
								</div>
							</div>
						</div>
					</div>
				</div>
				
                <div class="padd-vertical-45">
                        <script type="text/javascript" src="http://maps.google.com/maps/api/js?sensor=false"></script>
                        <div id="map_canvas" style="height: 450px; width: 100%;">
                        <script type="text/javascript"> 
                            function init_map(){
                                var myOptions = {zoom:14,center:new google.maps.LatLng(40.805478,-73.96522499999998),
                                mapTypeId: google.maps.MapTypeId.ROADMAP};
                                map = new google.maps.Map(document.getElementById("map_canvas"), myOptions);
                                marker = new google.maps.Marker({map: map,position: new google.maps.LatLng(40.805478, -73.96522499999998)});
                                infowindow = new google.maps.InfoWindow({content:"<div class='noScroll'><b>Headquarter</b><br/>2880 Broadway<br/> New York</div>" });
                                google.maps.event.addListener(marker, "click", function(){infowindow.open(map,marker);});
                                infowindow.open(map,marker);}google.maps.event.addDomListener(window, 'load', init_map);
                        </script>
                </div>
                
            </div>
                
				<div class="padd-vertical-45">
					<div class="container">
						<div class="row">
			    			<div class="cell-7 contact-form fx" data-animate="fadeInLeft" id="contact">
			    				<h3 class="block-head">Get in Touch</h3>
			    				<div id="message" style="display: none;">
                                    <i class="fa fa-smile-o success-icon"></i>
                                    <p class="congrats">Thank You!</p>
                                    <p class="congratsTxt">Your Message was successfuly Sent , please click the link below to go to home page.</p>
                                    <div><a href="home.html" class="btn btn-large main-bg">Go to home page</a></div>
                                </div>
                                <form class="form-signin cform" method="post" action="php/contact.php" id="cform" autocomplete="on">
			    					<div class="form-input">
				    					<label>First name<span class="red">*</span></label>
				    					<input type="text" name="name" id="name" required="required">
			    					</div>
			    					<div class="form-input">
			    						<label>Email<span class="red">*</span></label>
			    						<input name="email" type="email" id="email" required="required">
			    					</div>
			    					<div class="form-input">
			    						<label>Phone</label>
			    						<input name="phone" type="text" id="phone">			    						
			    					</div>
			    					<div class="form-input">
			    						<label>Message<span class="red">*</span></label>
			    						<textarea name="message" cols="40" rows="7" id="messageTxt" spellcheck="true" required="required"></textarea>
			    					</div>
			    					<div  class="form-input">
                                        <div class="row">
                                            <div class="cell-12 margin-bottom-20"><img alt="" src="<?php echo $_SESSION['captcha']['image_src']; ?>" id='captchaimg' ></div>
                                            <input type="hidden" id="hidCap" value="<?php echo $_SESSION['captcha']['code']; ?>" data-error="The captcha code does not match!" />
                                            <div class="cell-3"><input id="captcha_input" name="captcha_input" type="text" required="required"></div>
                                            <div class="cell-6"><label for='message'>Enter the code above :</label><small>Can't read the image? click here to <a href='#' id="rfrshCaptcha">refresh</a></small></div>
                                        </div>
			    					</div>
			    					<div class="form-input">
			    						<input id="submit" name="submit" type="submit" class="btn btn-large main-bg" value="Submit">&nbsp;&nbsp;<input type="reset" class="btn btn-large" value="Reset" id="reset">
			    					</div>

			    				</form>
			    			</div>
			    			<div class="cell-5 contact-detalis">
			    				<h3 class="block-head">Contact Details</h3>
			    				<p class="fx" data-animate="fadeInRight">Lorem ipsum dolor sit amet, onsectetuer dipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat dipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat dipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.Lorem ipsum dolor sit amet, onsectetuer dipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet.</p>
			    				<hr class="hr-style4">
			    				<div class="clearfix"></div>
			    				<div class="padding-vertical">
			    					<div class="cell-5 fx" data-animate="fadeInRight">
				    					<h4 class="main-color bold">Office: USA</h4>
				    					<h5 >Address:</h5>
				    					<p>123, Second Sunrise Avenue New York,USA</p>
				    					<h5 >Email:</h5>
				    					<p>info@it-rays.com</p>
				    					<h5 >Phone:</h5>
				    					<p>+2 012 000 0000</p>
				    					<h5 >FAX:</h5>
				    					<p>+2 012 000 0001</p>
				    				</div>
				    				<div class="cell-2"><br></div>
				    				<div class="cell-5 fx" data-animate="fadeInRight">
				    					<h4 class="main-color bold">Office: Australia</h4>
				    					<h5 >Address:</h5>
				    					<p>123, Second Sunrise Avenue New York,USA</p>
				    					<h5 >Email:</h5>
				    					<p>info@it-rays.com</p>
				    					<h5 >Phone:</h5>
				    					<p>+2 012 000 0000</p>
				    					<h5 >FAX:</h5>
				    					<p>+2 012 000 0001</p>
				    				</div>
			    				</div>
			    			</div>
						</div>
					</div>
				</div>
				
			<!-- Content End -->
			
			<!-- Footer start -->
		    <footer id="footWrapper">
		    	<div class="footer-top">
				    <div class="container">
					    <div class="row">
					    	<!-- main menu footer cell start -->
						    <div class="cell-3">
							    <h3 class="block-head">Main Menu</h3>
							    <ul class="footer-menu">
								    <li><a href="home.html">Home Page</a></li>
								    <li><a href="about-us.html">About Us</a></li>
								    <li><a href="blog.html">Our Blog</a></li>
								    <li><a href="portfolio-4-cols.html">Our Portfolio</a></li>
								    <li><a href="FAQ.html">FAQ</a></li>
							    </ul>
						    </div>
						    <!-- main menu footer cell start -->
						    
						    <!-- Our Friends footer cell start -->
						    <div class="cell-3">
							    <h3 class="block-head">Our Friends</h3>
							    <ul class="footer-menu">
								    <li><a href="#">adipiscing elit Integer</a></li>
								    <li><a href="#">magna euismod</a></li>
								    <li><a href="#">purus molestie</a></li>
								    <li><a href="#">adipiscing elit Integer</a></li>
								    <li><a href="#">purus molestie</a></li>
							    </ul>
						    </div>
						    <!-- Our Friends footer cell start -->
						    
						    <!-- Useful Links footer cell start -->
						    <div class="cell-3">
						    	<h3 class="block-head">Useful Links</h3>
						    	<ul class="footer-menu">
								    <li><a href="privacy.html">Privacy policy</a></li>
								    <li><a href="terms.html">Terms of use</a></li>
								    <li><a href="#">purus molestie</a></li>
								    <li><a href="#">adipiscing elit Integer</a></li>
								    <li><a href="#">magna euismod</a></li>
							    </ul>
						    </div>
						    <!-- Useful Links footer cell start -->
						    
						    <!-- Tags Cloud footer cell start -->
						    <div class="cell-3">
							    <h3 class="block-head">Tag Cloud</h3>
							    <div class="tags">
							    	<a href="#">Design</a>
							    	<a href="#">User interface</a>
							    	<a href="#">Performance</a>
							    	<a href="#">Development</a>
							    	<a href="#">WordPress</a>
							    	<a href="#">SEO</a>
							    	<a href="#">Joomla</a>
							    	<a href="#">ASP.Net</a>
							    	<a href="#">SharePoint</a>
							    	<a href="#">Bootstrap</a>
							    </div>
						    </div>
						    <!-- Tags Cloud footer cell start -->
						    
						    <div class="clearfix"></div>
						    <hr class="hr-style5">
						    <div class="clearfix"></div>
						    
						    <!-- contact us footer cell start -->
					    	<div class="cell-3">
							    <h3 class="block-head">Keep in Touch</h3>
							    <ul>
								    <li class="footer-contact"><i class="fa fa-home"></i><span>123, Second Street name, Address.</span></li>
								    <li class="footer-contact"><i class="fa fa-globe"></i><span><a href="#">info@it-rays.com</a></span></li>
								    <li class="footer-contact"><i class="fa fa-phone"></i><span>+1 (000) 000-0000</span></li>
								    <li class="footer-contact"><i class="fa fa-map-marker"></i><span><a href="contact.html#map_canvas">View our map</a></span></li>
							    </ul>
						    </div>
						    <!-- contact us footer cell end -->
						    
						    <!-- Newsletters footer cell start -->
					    	<div class="cell-3">
							    <div class="foot-logo"></div>
							    <p class="no-margin">Keep up on our always evolving product features and technology. Enter your e-mail and subscribe to our newsletter.</p>
							    <form action="http://it-rays.us9.list-manage.com/subscribe/post-json?u=8ff98fda7c9727d2b65a45ac2&amp;id=29d0e843d7&amp;c=?" method="post" id="mc-embedded-subscribe-form" name="mc-embedded-subscribe-form" target="_blank" novalidate class="NL">
							      <div class="skew-25 input-box left">
						         		 <input type="email" value="" name="EMAIL" class="txt-box skew25" id="mce-EMAIL" placeholder="Enter Yor Email" required>
						          </div>
						          <div class="left skew-25 NL-btn">
						         		 <input type="submit" value="Send" name="subscribe" id="mc-embedded-subscribe" class="btn skew25">
						          </div>
						          <div class="hidden"><input type="text" name="b_8ff98fda7c9727d2b65a45ac2_29d0e843d7" value=""></div>

   								 <div class="Notfication fx animated fadeInRight">
   								 <a class="close-box" href="#"><i class="fa fa-times"></i></a>
   									<p></p>
   								 </div>
						        </form>
						    </div>
						    <!-- Newsletters footer cell start -->
						    
						    <!-- latest tweets footer cell start -->
						    <div class="cell-3">
						    	<h3 class="block-head">Latest Tweets</h3>
						    	<div id="twitter-feed" class="tweet"></div>
						    </div>
						    <!-- latest tweets footer cell start -->
						    
						    <!-- flickr stream footer cell start -->
						    <div class="cell-3 flickr-stream-w">
						    	<h3 class="block-head">Flickr Stream</h3>
						    	<ul id="flickrFeed"></ul>
						    </div>
						    <!-- flickr stream footer cell start -->
						    
					    </div>
				    </div>	
			    </div>
			    
			    <!-- footer bottom bar start -->
			    <div class="footer-bottom">
				    <div class="container">
			    		<div class="row">
				    		<!-- footer copyrights left cell -->
				    		<div class="copyrights cell-5">&copy; Copyrights <b>EXCEPTION</b> 2014. All rights reserved. <span><a href="privacy.html">Privacy policy</a> | <a href="terms.html">Terms of use</a></span></div>
				    		
				    		<!-- footer social links right cell start -->
						    <div class="cell-7">
							    <ul class="social-list right">
								    <li class="skew-25"><a href="#" data-title="dribbble" data-tooltip="true"><span class="fa fa-dribbble skew25"></span></a></li>
								    <li class="skew-25"><a href="#" data-title="facebook" data-tooltip="true"><span class="fa fa-facebook skew25"></span></a></li>
								    <li class="skew-25"><a href="#" data-title="linkedin" data-tooltip="true"><span class="fa fa-linkedin skew25"></span></a></li>
								    <li class="skew-25"><a href="#" data-title="skype" data-tooltip="true"><span class="fa fa-skype skew25"></span></a></li>
								    <li class="skew-25"><a href="#" data-title="tumbler" data-tooltip="true"><span class="fa fa-tumblr skew25"></span></a></li>
								    <li class="skew-25"><a href="#" data-title="twitter" data-tooltip="true"><span class="fa fa-twitter skew25"></span></a></li>
								    <li class="skew-25"><a href="#" data-title="YouTube" data-tooltip="true"><span class="fa fa-youtube skew25"></span></a></li>
							    </ul>
						    </div>
						    <!-- footer social links right cell end -->
						    
			    		</div>
				    </div>
			    </div>
			    <!-- footer bottom bar end -->
			    
		    </footer>
		    <!-- Footer end -->
		    
		    <!-- Back to top Link -->
	    	<div id="to-top" class="main-bg"><span class="fa fa-chevron-up"></span></div>
	    
	    </div>
	    
	    <div class="ModalPopUp">
	    	<div class="ModalContainer">
	    		<div class="Modalheader">
	    			<h3></h3>
	    			<a href="#" class="closePopup"><span class="fa fa-times"></span></a>
	    		</div>
	    		<div class="ModalContent">
	    		</div>
	    	</div>
	    </div>
	    <!-- Load JS siles -->	    <script type="text/javascript" src="js/jquery.min.js"></script>
	    
	    <!-- Waypoints script -->
		<script type="text/javascript" src="js/waypoints.min.js"></script>
		
		<!-- SLIDER REVOLUTION SCRIPTS  -->
		<script type="text/javascript" src="rs-plugin/js/jquery.themepunch.tools.min.js"></script>
		<script type="text/javascript" src="rs-plugin/js/jquery.themepunch.revolution.min.js"></script>
		
		<!-- Animate numbers increment -->
		<script type="text/javascript" src="js/jquery.animateNumber.min.js"></script>
		
		<!-- slick slider carousel -->
		<script type="text/javascript" src="js/slick.min.js"></script>
		
		<!-- Animate numbers increment -->
		<script type="text/javascript" src="js/jquery.easypiechart.min.js"></script>
		
		<!-- PrettyPhoto script -->
		<script type="text/javascript" src="js/jquery.prettyPhoto.js"></script>
		
		<!-- Share post plugin script -->
		<script type="text/javascript" src="js/jquery.sharrre.min.js"></script>
		
		<!-- Product images zoom plugin -->
		<script type="text/javascript" src="js/jquery.elevateZoom-3.0.8.min.js"></script>
		
		<!-- Input placeholder plugin -->
		<script type="text/javascript" src="js/jquery.placeholder.js"></script>
		
		<!-- Contact us js file -->
		<script type="text/javascript" src="js/contact.js"></script>
		
		<!-- Tweeter API plugin -->
		<script type="text/javascript" src="js/twitterfeed.js"></script>
		
		<!-- Tweeter API plugin -->
		<script type="text/javascript" src="js/jflickrfeed.min.js"></script>
		
		<!-- NiceScroll plugin -->
		<script type="text/javascript" src="js/jquery.nicescroll.min.js"></script>
		
		<!-- jquery cookie script file -->
		<script type="text/javascript" src="js/jquery.cookie.js"></script><script type="text/javascript" src="js/mailChimp.js"></script>

		<!-- Style script file -->
		<script type="text/javascript" src="js/jquery.style.js"></script>
		
		<!-- general script file -->
		<script type="text/javascript" src="js/script.js"></script>
	</body>
</html>