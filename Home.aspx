<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="toptours1.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
		<meta charset="utf-8"/>
		<meta http-equiv="X-UA-Compatible" content="IE=edge"/>
		<meta name="viewport" content="width=device-width, initial-scale=1"/>

		<!--font-family-->
		<link href="https://fonts.googleapis.com/css?family=Rufina:400,700" rel="stylesheet" />

		<link href="https://fonts.googleapis.com/css?family=Poppins:100,200,300,400,500,600,700,800,900" rel="stylesheet" />

		<!-- title of the website -->
		<title>Top-Tours</title>

		<!-- favicon img -->
		<link rel="shortcut icon" type="image/icon" href="assets/logo/logo.png"/>

		<!--font-awesome.min.css-->
		<link rel="stylesheet" href="assets/css/font-awesome.min.css" />

		<!--animate.css-->
		<link rel="stylesheet" href="assets/css/animate.css" />

		<!--hover.css-->
		<link rel="stylesheet" href="assets/css/hover-min.css"/>

		<!--datepicker.css-->
		<link rel="stylesheet"  href="assets/css/datepicker.css" />

		<!--owl.carousel.css-->
        <link rel="stylesheet" href="assets/css/owl.carousel.min.css"/>
		<link rel="stylesheet" href="assets/css/owl.theme.default.min.css"/>

		<!-- range css-->
        <link rel="stylesheet" href="assets/css/jquery-ui.min.css" />

		<!--bootstrap.min.css-->
		<link rel="stylesheet" href="assets/css/bootstrap.min.css" />

		<!-- bootsnav -->
		<link rel="stylesheet" href="assets/css/bootsnav.css"/>

		<!--style.css-->
		<link rel="stylesheet" href="assets/css/style.css" />

		<!--Responsive.css-->
		<link rel="stylesheet" href="assets/css/responsive.css" />
</head>
<body>
		<header class="top-area">
			<div class="header-area">
				<div class="container">
					<div class="row">
						<div class="col-sm-2">
							<div class="logo">
								<a href="Home.aspx">
									Top<span>Tours</span>
								</a>
							</div>
						</div>
						<div class="col-sm-11">
							<div class="main-menu">
								<div class="navbar-header">
									<button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
										<i class="fa fa-bars"></i>
									</button>
								</div>
								<div class="collapse navbar-collapse">		  
									<ul class="nav navbar-nav navbar-right">
										<li class="smooth-menu"><a href="#home">home</a></li>
										<li class="smooth-menu"><a href="#gallery">Tours</a></li>
										<li class="smooth-menu"><a href="#pack">Places</a></li>
										<li class="smooth-menu"><a href="#spo">Special Offer</a></li>
										<li class="smooth-menu"><a href="#blog">Reviews</a></li>
										<li>    <form runat="server">
												<asp:Button  runat="server" class="book-btn" text="logout"
                                                  OnClick="Button1_Click"  />
											    </form>
										</li> 
									</ul>
								</div>
							</div>
						</div>
					</div>
					<div class="home-border"></div>
				</div>
			</div>
		</header>
		<section id="home" class="about-us">
			<div class="container">
				<div class="about-us-content">
					<div class="row">
						<div class="col-sm-12">
							<div class="single-about-us">
								<div class="about-us-txt">
									<h2>
										Explore The Beauty Of The World By Our Tours!!

									</h2>
									<div class="about-btn">
										<input type="button" name="submit" value="Profile" class="about-view" onclick="location.href = 'Profile.aspx';"/>
									</div>
								</div>
							</div>
						</div>
						<div class="col-sm-0">
							<div class="single-about-us">
							</div>
						</div>
					</div>
				</div>
			</div>

		</section>

		<section  class="travel-box">
        	<div class="container">
        		<div class="row">
        			<div class="col-md-12">
        				<div class="single-travel-boxes">
        					<div id="desc-tabs" class="desc-tabs">

								<ul class="nav nav-tabs" role="tablist">

									<li role="presentation" class="active">
									 	<a href="#tours" aria-controls="tours" role="tab" data-toggle="tab">
									 		<i class="fa fa-tree"></i>
									 		tours
									 	</a>
									</li>			
								</ul>
								<div class="tab-content">

									<div role="tabpanel" class="tab-pane active fade in" id="tours">
										<div class="tab-para">

											<div class="row">
												<div class="col-lg-4 col-md-4 col-sm-12">
													<div class="single-tab-select-box">

														<h2>destination</h2>

														<div class="travel-select-icon">
															<select class="form-control ">

															  	<option value="default">enter your destination country</option>

															  	<option value="turkey">turkey</option>

															  	<option value="russia">russia</option>
															  	<option value="egept">egypt</option>

															</select>
														</div>

														<div class="travel-select-icon">
															<select class="form-control ">

															  	<option value="default">enter your destination location</option>

															  	<option value="istambul">istambul</option>

															  	<option value="mosko">mosko</option>
															  	<option value="cairo">cairo</option>

															</select>
														</div>

													</div>
												</div>

												<div class="col-lg-2 col-md-3 col-sm-4">
													<div class="single-tab-select-box">
														<h2>check in</h2>
														<div class="travel-check-icon">
															<form action="#">
																<input type="text" name="check_in" class="form-control" data-toggle="datepicker" placeholder="12 -01 - 2017 "/>
															</form>
														</div>
													</div>
												</div>

												<div class="col-lg-2 col-md-3 col-sm-4">
													<div class="single-tab-select-box">
														<h2>check out</h2>
														<div class="travel-check-icon">
															<form action="#">
																<input type="text" name="check_out" class="form-control"  data-toggle="datepicker" placeholder="22 -01 - 2017 "/>
															</form>
														</div>
													</div>
												</div>

												<div class="col-lg-2 col-md-1 col-sm-4">
													<div class="single-tab-select-box">
														<h2>duration</h2>
														<div class="travel-select-icon">
															<select class="form-control ">

															  	<option value="default">5</option>

															  	<option value="10">10</option>

															  	<option value="15">15</option>
															  	<option value="20">20</option>

															</select>
														</div>
													</div>
												</div>

												<div class="col-lg-2 col-md-1 col-sm-4">
													<div class="single-tab-select-box">
														<h2>members</h2>
														<div class="travel-select-icon">
															<select class="form-control ">

															  	<option value="default">1</option>

															  	<option value="2">2</option>

															  	<option value="4">4</option>
															  	<option value="8">8</option>

															</select>
														</div>
													</div>
												</div>

											</div>

											<div class="row">
												<div class="col-sm-5">
													<div class="travel-budget">
														<div class="row">
															<div class="col-md-3 col-sm-4">
																<h3>budget : </h3>
															</div>
															<div class="co-md-9 col-sm-8">
																<div class="travel-filter">
																	<div class="info_widget">
																		<div class="price_filter">
																			
																			<div id="slider-range"></div>

																			<div class="price_slider_amount">
																				<input type="text" id="amount" name="price"  placeholder="Add Your Price" />
																			</div>
																		</div>
																	</div>
																</div>
															</div>
														</div>
													</div>
												</div>
												<div class="clo-sm-7">
													<div class="about-btn travel-mrt-0 pull-right">
														<button  class="about-view travel-btn">
															search	
														</button>
													</div>
												</div>
											</div>
										</div>
									</div>
											<div class="row">
												<div class="col-lg-4 col-md-4 col-sm-12">
													<div class="single-tab-select-box">

														<h2>to</h2>

														<div class="travel-select-icon">
															<select class="form-control ">

															  	<option value="default">enter your destination location</option><!-- /.option-->

															  	<option value="istambul">istambul</option><!-- /.option-->

															  	<option value="mosko">mosko</option><!-- /.option-->
															  	<option value="cairo">cairo</option><!-- /.option-->

															</select><!-- /.select-->
														</div><!-- /.travel-select-icon -->

													</div><!--/.single-tab-select-box-->
												</div><!--/.col-->
												<div class="col-lg-3 col-md-3 col-sm-4">
													<div class="single-tab-select-box">

														<h2>class</h2>
														<div class="travel-select-icon">
															<select class="form-control ">

															  	<option value="default">enter class</option><!-- /.option-->

															  	<option value="A">A</option><!-- /.option-->

															  	<option value="B">B</option><!-- /.option-->
															  	<option value="C">C</option><!-- /.option-->

															</select><!-- /.select-->
														</div><!-- /.travel-select-icon -->
													</div><!--/.single-tab-select-box-->
												</div><!--/.col-->
												<div class="clo-sm-5">
													<div class="about-btn pull-right">
														<button  class="about-view travel-btn">
															search	
														</button><!--/.travel-btn-->
													</div><!--/.about-btn-->
												</div><!--/.col-->
												
											</div><!--/.row-->

										</div>

									</div><!--/.tabpannel-->

								</div><!--/.tab content-->
							</div><!--/.desc-tabs-->
        				</div><!--/.single-travel-box-->
        			</div><!--/.col-->
        	<%--	</div><!--/.row-->--%>
        	<%--</div><!--/.container-->--%>

        </section><!--/.travel-box-->
		<section id="service" class="service">
			<div class="container">

				<div class="service-counter text-center">

					<div class="col-md-4 col-sm-4">
						<div class="single-service-box">
							<div class="service-img">
								<img src="assets/images/service/s1.png" alt="service-icon" />
							</div>
							<div class="service-content">
								<h2>
									<a href="#">
									amazing tour packages
									</a>
								</h2>
								<p>Duis aute irure dolor in  velit esse cillum dolore eu fugiat nulla.</p>
							</div>
						</div>
					</div>

					<div class="col-md-4 col-sm-4">
						<div class="single-service-box">
							<div class="service-img">
								<img src="assets/images/service/s2.png" alt="service-icon" />
							</div>
							<div class="service-content">
								<h2>
									<a href="#">
										book top class hotel
									</a>
								</h2>
								<p>Duis aute irure dolor in  velit esse cillum dolore eu fugiat nulla.</p>
							</div>
						</div>
					</div>

					<div class="col-md-4 col-sm-4">
						<div class="single-service-box">
							<div class="statistics-img">
								<img src="assets/images/service/s3.png" alt="service-icon" />
							</div>
							<div class="service-content">
								<h2>
									<a href="#">
										online flight booking
									</a>
								</h2>
								<p>Duis aute irure dolor in  velit esse cillum dolore eu fugiat nulla.</p>
							</div>
						</div>
					</div>
				</div>
			</div>
		</section>
		<section id="gallery" class="gallery">
			<div class="container">
				<div class="gallery-details">
					<div class="gallary-header text-center">
						<h2>
							top destination
						</h2>
						<p>
							Duis aute irure dolor in  velit esse cillum dolore eu fugiat nulla.  
						</p>
					</div>
					<div class="gallery-box">
						<div class="gallery-content">
						  	<div class="filtr-container">
						  		<div class="row">

						  			<div class="col-md-6">
						  				<div class="filtr-item">
											<img src="assets/images/gallary/g1.jpg" alt="portfolio image"/>
											<div class="item-title">
												<a href="#">
													china
												</a>
												<p><span>20 tours</span><span>15 places</span></p>
											</div>
										</div>
						  			</div>

						  			<div class="col-md-6">
						  				<div class="filtr-item">
											<img src="assets/images/gallary/g2.jpg" alt="portfolio image"/>
											<div class="item-title">
												<a href="#">
													venuzuala
												</a>
												<p><span>12 tours</span><span>9 places</span></p>
											</div>
										</div>
						  			</div>

						  			<div class="col-md-4">
						  				<div class="filtr-item">
											<img src="assets/images/gallary/g3.jpg" alt="portfolio image"/>
											<div class="item-title">
												<a href="#">
													brazil
												</a>
												<p><span>25 tours</span><span>10 places</span></p>
											</div>
										</div>
						  			</div>

						  			<div class="col-md-4">
						  				<div class="filtr-item">
											<img src="assets/images/gallary/g4.jpg" alt="portfolio image"/>
											<div class="item-title">
												<a href="#">
													australia 
												</a>
												<p><span>18 tours</span><span>9 places</span></p>
											</div>
										</div>
						  			</div>
						  			<div class="col-md-4">
						  				<div class="filtr-item">
											<img src="assets/images/gallary/g5.jpg" alt="portfolio image"/>
											<div class="item-title">
												<a href="#">
													netharland
												</a>
												<p><span>14 tours</span><span>12 places</span></p>
											</div> 
										</div>
						  			</div>
						  			<div class="col-md-8">
						  				<div class="filtr-item">
											<img src="assets/images/gallary/g6.jpg" alt="portfolio image"/>
											<div class="item-title">
												<a href="#">
													turkey
												</a>
												<p><span>14 tours</span><span>6 places</span></p>
											</div>
										</div>
						  			</div>
						  		</div>
						  	</div>
						</div>
					</div>
				</div>
			</div>
		</section>
		<section id="pack" class="packages">
			<div class="container">
				<div class="gallary-header text-center">
					<h2>
						special packages
					</h2>
					<p>
						Duis aute irure dolor in  velit esse cillum dolore eu fugiat nulla.  
					</p>
				</div>
				<div class="packages-content">
					<div class="row">

						<div class="col-md-4 col-sm-6">
							<div class="single-package-item">
								<img src="assets/images/packages/p1.jpg" alt="package-place"/>
								<div class="single-package-item-txt">
									<h3>italy <span class="pull-right">$499</span></h3>
									<div class="packages-para">
										<p>
											<span>
												<i class="fa fa-angle-right"></i> 5 daays 6 nights
											</span>
											<i class="fa fa-angle-right"></i>  5 star accomodation
										</p>
										<p>
											<span>
												<i class="fa fa-angle-right"></i>  transportation
											</span>
											<i class="fa fa-angle-right"></i>  food facilities
										 </p>
									</div>
									<div class="packages-review">
										<p>
											<i class="fa fa-star"></i>
											<i class="fa fa-star"></i>
											<i class="fa fa-star"></i>
											<i class="fa fa-star"></i>
											<i class="fa fa-star"></i>
											<span>2544 review</span>
										</p>
									</div>
									<div class="about-btn">
										<button  class="about-view packages-btn">
											book now
										</button>
									</div>
								</div>
							</div>
						</div>

						<div class="col-md-4 col-sm-6">
							<div class="single-package-item">
								<img src="assets/images/packages/p2.jpg" alt="package-place"/>
								<div class="single-package-item-txt">
									<h3>england <span class="pull-right">$1499</span></h3>
									<div class="packages-para">
										<p>
											<span>
												<i class="fa fa-angle-right"></i> 5 daays 6 nights
											</span>
											<i class="fa fa-angle-right"></i>  5 star accomodation
										</p>
										<p>
											<span>
												<i class="fa fa-angle-right"></i>  transportation
											</span>
											<i class="fa fa-angle-right"></i>  food facilities
										 </p>
									</div>
									<div class="packages-review">
										<p>
											<i class="fa fa-star"></i>
											<i class="fa fa-star"></i>
											<i class="fa fa-star"></i>
											<i class="fa fa-star"></i>
											<i class="fa fa-star"></i>
											<span>2544 review</span>
										</p>
									</div>
									<div class="about-btn">
										<button  class="about-view packages-btn">
											book now
										</button>
									</div>
								</div>
							</div>
						</div>
						<div class="col-md-4 col-sm-6">
							<div class="single-package-item">
								<img src="assets/images/packages/p3.jpg" alt="package-place"/>
								<div class="single-package-item-txt">
									<h3>france <span class="pull-right">$1199</span></h3>
									<div class="packages-para">
										<p>
											<span>
												<i class="fa fa-angle-right"></i> 5 daays 6 nights
											</span>
											<i class="fa fa-angle-right"></i>  5 star accomodation
										</p>
										<p>
											<span>
												<i class="fa fa-angle-right"></i>  transportation
											</span>
											<i class="fa fa-angle-right"></i>  food facilities
										 </p>
									</div>
									<div class="packages-review">
										<p>
											<i class="fa fa-star"></i>
											<i class="fa fa-star"></i>
											<i class="fa fa-star"></i>
											<i class="fa fa-star"></i>
											<i class="fa fa-star"></i>
											<span>2544 review</span>
										</p>
									</div>
									<div class="about-btn">
										<button  class="about-view packages-btn">
											book now
										</button>
									</div>
								</div>
							</div>
						</div>
						<div class="col-md-4 col-sm-6">
							<div class="single-package-item">
								<img src="assets/images/packages/p4.jpg" alt="package-place"/>
								<div class="single-package-item-txt">
									<h3>india <span class="pull-right">$799</span></h3>
									<div class="packages-para">
										<p>
											<span>
												<i class="fa fa-angle-right"></i> 5 daays 6 nights
											</span>
											<i class="fa fa-angle-right"></i>  5 star accomodation
										</p>
										<p>
											<span>
												<i class="fa fa-angle-right"></i>  transportation
											</span>
											<i class="fa fa-angle-right"></i>  food facilities
										 </p>
									</div>
									<div class="packages-review">
										<p>
											<i class="fa fa-star"></i>
											<i class="fa fa-star"></i>
											<i class="fa fa-star"></i>
											<i class="fa fa-star"></i>
											<i class="fa fa-star"></i>
											<span>2544 review</span>
										</p>
									</div>
									<div class="about-btn">
										<button  class="about-view packages-btn">
											book now
										</button>
									</div>
								</div>
							</div>
						</div>
						
						<div class="col-md-4 col-sm-6">
							<div class="single-package-item">
								<img src="assets/images/packages/p5.jpg" alt="package-place"/>
								<div class="single-package-item-txt">
									<h3>spain <span class="pull-right">$999</span></h3>
									<div class="packages-para">
										<p>
											<span>
												<i class="fa fa-angle-right"></i> 5 daays 6 nights
											</span>
											<i class="fa fa-angle-right"></i>  5 star accomodation
										</p>
										<p>
											<span>
												<i class="fa fa-angle-right"></i>  transportation
											</span>
											<i class="fa fa-angle-right"></i>  food facilities
										 </p>
									</div>
									<div class="packages-review">
										<p>
											<i class="fa fa-star"></i>
											<i class="fa fa-star"></i>
											<i class="fa fa-star"></i>
											<i class="fa fa-star"></i>
											<i class="fa fa-star"></i>
											<span>2544 review</span>
										</p>
									</div>
									<div class="about-btn">
										<button  class="about-view packages-btn">
											book now
										</button>
									</div>
								</div>
							</div>
						</div>
						
						<div class="col-md-4 col-sm-6">
							<div class="single-package-item">
								<img src="assets/images/packages/p6.jpg" alt="package-place"/>
								<div class="single-package-item-txt">
									<h3>thailand <span class="pull-right">$799</span></h3>
									<div class="packages-para">
										<p>
											<span>
												<i class="fa fa-angle-right"></i> 5 daays 6 nights
											</span>
											<i class="fa fa-angle-right"></i>  5 star accomodation
										</p>
										<p>
											<span>
												<i class="fa fa-angle-right"></i>  transportation
											</span>
											<i class="fa fa-angle-right"></i>  food facilities
										 </p>
                                    </div>
                                    <!--/.packages-para-->
                                    <div class="packages-review">
                                        <p>
                                            <%
                                                for (int i = 0; i < 4; i++)
                                                {
                                            %>
                                            <i class="fa fa-star"></i>
                                            <% }%>
                                            <span>2544 review</span>
                                        </p>
                                    </div>
                                    <!--/.packages-review-->
                                    <div class="about-btn">
										<button  class="about-view packages-btn">
											book now
										</button>
									</div><!--/.about-btn-->
								</div><!--/.single-package-item-txt-->
							</div><!--/.single-package-item-->

						</div><!--/.col-->

					</div><!--/.row-->
				</div><!--/.packages-content-->
			</div><!--/.container-->

		</section><!--/.packages-->
		<section   class="testemonial">
			<div class="container">

				<div class="gallary-header text-center">
					<h2>
						clients reviews
					</h2>
					<p>
						Duis aute irure dolor in  velit esse cillum dolore eu fugiat nulla. 
					</p>

				</div><!--/.gallery-header-->

				<div class="owl-carousel owl-theme" id="testemonial-carousel">

					<div class="home1-testm item">
						<div class="home1-testm-single text-center">
							<div class="home1-testm-img">
								<img src="assets/images/client/testimonial1.jpg" alt="img"/>
							</div><!--/.home1-testm-img-->
							<div class="home1-testm-txt">
								<span class="icon section-icon">
									<i class="fa fa-quote-left" aria-hidden="true"></i>
								</span>
								<p>
									Lorem ipsum dolor sit amet, contur adip elit, sed do mod incid ut labore et dolore magna aliqua. Ut enim ad minim veniam. 
								</p>
								<h3>
									<a href="#">
										kevin watson
									</a>
								</h3>
								<h4>london, england</h4>
							</div><!--/.home1-testm-txt-->	
						</div><!--/.home1-testm-single-->

					</div><!--/.item-->

					<div class="home1-testm item">
						<div class="home1-testm-single text-center">
							<div class="home1-testm-img">
								<img src="assets/images/client/testimonial2.jpg" alt="img"/>
							</div><!--/.home1-testm-img-->
							<div class="home1-testm-txt">
								<span class="icon section-icon">
									<i class="fa fa-quote-left" aria-hidden="true"></i>
								</span>
								<p>
									Lorem ipsum dolor sit amet, contur adip elit, sed do mod incid ut labore et dolore magna aliqua. Ut enim ad minim veniam. 
								</p>
								<h3>
									<a href="#">
										kevin watson
									</a>
								</h3>
								<h4>london, england</h4>
							</div><!--/.home1-testm-txt-->	
						</div><!--/.home1-testm-single-->

					</div><!--/.item-->

					<div class="home1-testm item">
						<div class="home1-testm-single text-center">
							<div class="home1-testm-img">
								<img src="assets/images/client/testimonial1.jpg" alt="img"/>
							</div><!--/.home1-testm-img-->
							<div class="home1-testm-txt">
								<span class="icon section-icon">
									<i class="fa fa-quote-left" aria-hidden="true"></i>
								</span>
								<p>
									Lorem ipsum dolor sit amet, contur adip elit, sed do mod incid ut labore et dolore magna aliqua. Ut enim ad minim veniam. 
								</p>
								<h3>
									<a href="#">
										kevin watson
									</a>
								</h3>
								<h4>london, england</h4>
							</div><!--/.home1-testm-txt-->	
						</div><!--/.home1-testm-single-->

					</div><!--/.item-->

					<div class="home1-testm item">
						<div class="home1-testm-single text-center">
							<div class="home1-testm-img">
								<img src="assets/images/client/testimonial1.jpg" alt="img"/>
							</div><!--/.home1-testm-img-->
							<div class="home1-testm-txt">
								<span class="icon section-icon">
									<i class="fa fa-quote-left" aria-hidden="true"></i>
								</span>
								<p>
									Lorem ipsum dolor sit amet, contur adip elit, sed do mod incid ut labore et dolore magna aliqua. Ut enim ad minim veniam. 
								</p>
								<h3>
									<a href="#">
										kevin watson
									</a>
								</h3>
								<h4>london, england</h4>
							</div><!--/.home1-testm-txt-->	
						</div><!--/.home1-testm-single-->

					</div><!--/.item-->

					<div class="home1-testm item">
						<div class="home1-testm-single text-center">
							<div class="home1-testm-img">
								<img src="assets/images/client/testimonial2.jpg" alt="img"/>
							</div><!--/.home1-testm-img-->
							<div class="home1-testm-txt">
								<span class="icon section-icon">
									<i class="fa fa-quote-left" aria-hidden="true"></i>
								</span>
								<p>
									Lorem ipsum dolor sit amet, contur adip elit, sed do mod incid ut labore et dolore magna aliqua. Ut enim ad minim veniam. 
								</p>
								<h3>
									<a href="#">
										kevin watson
									</a>
								</h3>
								<h4>london, england</h4>
							</div><!--/.home1-testm-txt-->	
						</div><!--/.home1-testm-single-->

					</div><!--/.item-->

					<div class="home1-testm item">
						<div class="home1-testm-single text-center">
							<div class="home1-testm-img">
								<img src="assets/images/client/testimonial1.jpg" alt="img"/>
							</div><!--/.home1-testm-img-->
							<div class="home1-testm-txt">
								<span class="icon section-icon">
									<i class="fa fa-quote-left" aria-hidden="true"></i>
								</span>
								<p>
									Lorem ipsum dolor sit amet, contur adip elit, sed do mod incid ut labore et dolore magna aliqua. Ut enim ad minim veniam. 
								</p>
								<h3>
									<a href="#">
										kevin watson
									</a>
								</h3>
								<h4>london, england</h4>
							</div>
						</div>

					</div>

					<div class="home1-testm item">
						<div class="home1-testm-single text-center">
							<div class="home1-testm-img">
								<img src="assets/images/client/testimonial1.jpg" alt="img"/>
							</div>
							<div class="home1-testm-txt">
								<span class="icon section-icon">
									<i class="fa fa-quote-left" aria-hidden="true"></i>
								</span>
								<p>
									Lorem ipsum dolor sit amet, contur adip elit, sed do mod incid ut labore et dolore magna aliqua. Ut enim ad minim veniam. 
								</p>
								<h3>
									<a href="#">
										kevin watson
									</a>
								</h3>
								<h4>london, england</h4>
							</div>	
						</div>

					</div>

					<div class="home1-testm item">
						<div class="home1-testm-single text-center">
							<div class="home1-testm-img">
								<img src="assets/images/client/testimonial2.jpg" alt="img"/>
							</div>
							<div class="home1-testm-txt">
								<span class="icon section-icon">
									<i class="fa fa-quote-left" aria-hidden="true"></i>
								</span>
								<p>
									Lorem ipsum dolor sit amet, contur adip elit, sed do mod incid ut labore et dolore magna aliqua. Ut enim ad minim veniam. 
								</p>
								<h3>
									<a href="#">
										kevin watson
									</a>
								</h3>
								<h4>London, England</h4>
							</div>
						</div>

					</div>

					<div class="home1-testm item">
						<div class="home1-testm-single text-center">
							<div class="home1-testm-img">
								<img src="assets/images/client/testimonial1.jpg" alt="img"/>
							</div>
							<div class="home1-testm-txt">
								<span class="icon section-icon">
									<i class="fa fa-quote-left" aria-hidden="true"></i>
								</span>
								<p>
									Lorem ipsum dolor sit amet, contur adip elit, sed do mod incid ut labore et dolore magna aliqua. Ut enim ad minim veniam. 
								</p>
								<h3>
									<a href="#">
										kevin watson
									</a>
								</h3>
								<h4>london, england</h4>
							</div>
						</div>
					</div>
				</div>
			</div>

		</section>		
		<section id="spo" class="special-offer">
			<div class="container">
				<div class="special-offer-content">
					<div class="row">
						<div class="col-sm-8">
							<div class="single-special-offer">
								<div class="single-special-offer-txt">
									<h2>thiland</h2>
									<div class="packages-review special-offer-review">
										<p>
											<i class="fa fa-star"></i>
											<i class="fa fa-star"></i>
											<i class="fa fa-star"></i>
											<i class="fa fa-star"></i>
											<i class="fa fa-star"></i>
											<span>2544 review</span>
										</p>
									</div>
									<div class="packages-para special-offer-para">
										<p>
											<span>
												<i class="fa fa-angle-right"></i> 5 daays 6 nights
											</span>
											<span>
												<i class="fa fa-angle-right"></i> 2 person
											</span>
											<span>
												<i class="fa fa-angle-right"></i>  5 star accomodation
											</span>
										</p>
										<p>
											<span>
												<i class="fa fa-angle-right"></i>  transportation
											</span>
											<span>
												<i class="fa fa-angle-right"></i>  food facilities
											</span>  
										</p>
										<p class="offer-para">
											Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tem ut labore et dolore magna  aliqua. Ut enim ad minim veniam, quis nostrud exercitation una <br/> ullamco laboris nisi ut aliquip ex ea commodo consequat. 
										</p>
									</div>
									<div class="offer-btn-group">
										<div class="about-btn">
											<button  class="about-view packages-btn offfer-btn">
												make tour
											</button>
										</div>
										<div class="about-btn">
											<button  class="about-view packages-btn">
												book now
											</button>
										</div>
									</div>
								</div>
							</div>
						</div>
						<div class="col-sm-4">
							<div class="single-special-offer">
								<div class="single-special-offer-bg">
									<img src="assets/images/offer/offer-shape.png" alt="offer-shape"/>
								</div>
								<div class="single-special-shape-txt">
									<h3>special offer</h3>
									<h4><span>40%</span><br/>off</h4>
									<p><span>$999</span><br/>reguler $ 1450</p>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</section>
		<section id="blog" class="blog">
			<div class="container">
				<div class="blog-details">
						<div class="gallary-header text-center">
							<h2>
								latest news
							</h2>
							<p>
								Travel News from all over the world 
							</p>
						</div>
						<div class="blog-content">
							<div class="row">

								<div class="col-sm-4 col-md-4">
									<div class="thumbnail">
										<h2>trending news <span>15 november 2017</span></h2>
										<div class="thumbnail-img">
											<img src="assets/images/blog/b1.jpg" alt="blog-img"/>
											<div class="thumbnail-img-overlay"></div>
										</div>
										<div class="caption">
											<div class="blog-txt">
												<h3>
													<a href="#">
														Discover on beautiful weather, Fantastic foods and historical place in Prag
													</a>
												</h3>
												<p>
													Lorem ipsum dolor sit amet, contur adip elit, sed do mod incid ut labore et dolore magna aliqua. Ut enim ad minim veniam 
												</p>
												<a href="#">Read More</a>
											</div>
										</div>
									</div>
								</div>
								<div class="col-sm-4 col-md-4">
									<div class="thumbnail">
										<h2>trending news <span>15 november 2022</span></h2>
										<div class="thumbnail-img">
											<img src="assets/images/blog/b2.jpg" alt="blog-img"/>
											<div class="thumbnail-img-overlay"></div>
										
										</div>
										<div class="caption">
											<div class="blog-txt">
												<h3>
													<a href="#">
														Discover on beautiful weather, Fantastic foods and historical place in india
													</a>
												</h3>
												<p>
													We Are Happy To See You There
												</p>
												<a href="#">Read More</a>
											</div>
										</div>
									</div>

								</div>

								<div class="col-sm-4 col-md-4">
									<div class="thumbnail">
										<h2>trending news <span>15 november 2017</span></h2>
										<div class="thumbnail-img">
											<img src="assets/images/blog/b3.jpg" alt="blog-img"/>
											<div class="thumbnail-img-overlay"></div>
										</div>
										<div class="caption">
											<div class="blog-txt">
												<h3><a href="#">10 Most Natural place to Discover</a></h3>
												<p>
													Lorem ipsum dolor sit amet, contur adip elit, sed do mod incid ut labore et dolore magna aliqua. Ut enim ad minim veniam 
												</p>
												<a href="#">Read More</a>
											</div>
										</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>

		</section>

		<script src="assets/js/jquery.js"></script>
	

		<!--modernizr.min.js-->
		<script  src="https://cdnjs.cloudflare.com/ajax/libs/modernizr/2.8.3/modernizr.min.js"></script>


		<!--bootstrap.min.js-->
		<script  src="assets/js/bootstrap.min.js"></script>

		<!-- bootsnav js -->
		<script src="assets/js/bootsnav.js"></script>

		<!-- jquery.filterizr.min.js -->
		<script src="assets/js/jquery.filterizr.min.js"></script>

		<script  src="https://cdnjs.cloudflare.com/ajax/libs/jquery-easing/1.4.1/jquery.easing.min.js"></script>

		<!--jquery-ui.min.js-->
        <script src="assets/js/jquery-ui.min.js"></script>

        <!-- counter js -->
		<script src="assets/js/jquery.counterup.min.js"></script>
		<script src="assets/js/waypoints.min.js"></script>

		<!--owl.carousel.js-->
        <script  src="assets/js/owl.carousel.min.js"></script>

        <!-- jquery.sticky.js -->
		<script src="assets/js/jquery.sticky.js"></script>

        <!--datepicker.js-->
        <script  src="assets/js/datepicker.js"></script>

		<!--Custom JS-->
		<script src="assets/js/custom.js"></script>
</body>
</html>
