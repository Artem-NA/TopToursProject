<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NICK.aspx.cs" Inherits="toptours1.NICK" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    

    	<!--font-family-->
		<link href="https://fonts.googleapis.com/css?family=Rufina:400,700" rel="stylesheet" />

		<link href="https://fonts.googleapis.com/css?family=Poppins:100,200,300,400,500,600,700,800,900" rel="stylesheet" />

	  <title>vvvvvvvvvvvv</title>
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

    <link href="StyleSheets/ProfileSS.css" rel="stylesheet" />

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
										<li ><a href="Home.aspx">home</a></li>
										<li ><a href="Routes.aspx">Tours</a></li>
										<li  ><a href="PlacesPage.aspx">Places</a></li>
										<li  ><a href="ReviewsPage.aspx">Reviews</a></li>
										<li>    <form runat="server">
												<asp:Button  runat="server" class="book-btn" text="logout" />
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
	<%--End Of Header-----------------------------------------------------------------------------------------------------------------------------------------------------------------------%>

		<!--travel-box start-->
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
									 		Profile
									 	</a>
									</li>

									<li role="presentation">
										<a href="#hotels" aria-controls="hotels" role="tab" data-toggle="tab">
											<i class="fa fa-building"></i>
											Liked Routes
										</a>
									</li>

									<li role="presentation">
									 	<a href="#flights" aria-controls="flights" role="tab" data-toggle="tab">
									 		<i class="fa fa-plane"></i>
									 		Delete Account
									 	</a>
									</li>
								</ul>

								<!-- Tab panes -->
								<div class="tab-content">

									<div role="tabpanel" class="tab-pane active fade in" id="tours">
										<div class="tab-para">

											<div class="row">
												<div class="col-lg-4 col-md-4 col-sm-12">
													<div class="single-tab-select-box">

														<h2>Email</h2>

														
																<input type="email" class="form-control" placeholder="Enter your Email Here"/>
														<br />
														
														<h2>Password</h2>
													
															<input type="password" class="form-control" placeholder="Enter your password Here"/>
														

													</div><!--/.single-tab-select-box-->
												</div><!--/.col-->

												<div class="col-lg-2 col-md-3 col-sm-4">
													<div class="single-tab-select-box">
														
													</div><!--/.single-tab-select-box-->
												</div><!--/.col-->

												<div class="col-lg-2 col-md-3 col-sm-4">
													<div class="single-tab-select-box">
														
													</div><!--/.single-tab-select-box-->
												</div><!--/.col-->

												<div class="col-lg-2 col-md-1 col-sm-4 " style="padding-right: 6rem;">
													<div class="single-tab-select-box">
														<h2>Choose</h2>
														<div class="travel-select-icon">
															<select class="form-control ">

															  	<option value="default">Email</option><!-- /.option-->

															  	<option value="10">Username</option><!-- /.option-->

															  	<option value="15">Password</option><!-- /.option-->

															</select><!-- /.select-->
														</div><!-- /.travel-select-icon -->
													</div><!--/.single-tab-select-box-->
												</div><!--/.col-->

												<div class="col-lg-2 col-md-1 col-sm-4">
													<div class="single-tab-select-box">
													</div><!--/.single-tab-select-box-->
												</div><!--/.col-->

											</div><!--/.row-->

											<div class="row" style="width: 100%; padding: 0 55%;">
												<div class="col-sm-5">
													
												<div class="col-sm-7">
													<div class="about-btn travel-mrt-0 pull-right">
														<button  class="about-view travel-btn" >
															search	
														</button><!--/.travel-btn-->
													</div><!--/.about-btn-->
												</div><!--/.col-->
													</div>
											</div><!--/.row-->

										</div><!--/.tab-para-->

									</div><!--/.tabpannel-->

									<div role="tabpanel" class="tab-pane fade in" id="hotels">
										<div class="tab-para">

											<div class="row">
												<div class="col-lg-4 col-md-4 col-sm-12">
													<div class="single-tab-select-box">

														<h2>destination</h2>

														<div class="travel-select-icon">
															<select class="form-control ">

															  	<option value="default">enter your destination country</option><!-- /.option-->

															  	<option value="turkey">turkey</option><!-- /.option-->

															  	<option value="russia">russia</option><!-- /.option-->
															  	<option value="egept">egypt</option><!-- /.option-->

															</select><!-- /.select-->
														</div><!-- /.travel-select-icon -->

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

												<div class="col-lg-2 col-md-3 col-sm-4">
													<div class="single-tab-select-box">
														<h2>check in</h2>
														<div class="travel-check-icon">
															<form action="#">
																<input type="text" name="check_in" class="form-control" data-toggle="datepicker" placeholder="12 -01 - 2017 "/>
															</form>
														</div><!-- /.travel-check-icon -->
													</div><!--/.single-tab-select-box-->
												</div><!--/.col-->

												<div class="col-lg-2 col-md-3 col-sm-4">
													<div class="single-tab-select-box">
														<h2>check out</h2>
														<div class="travel-check-icon">
															<form action="#">
																<input type="text" name="check_out" class="form-control"  data-toggle="datepicker" placeholder="22 -01 - 2017 "/>
															</form>
														</div><!-- /.travel-check-icon -->
													</div><!--/.single-tab-select-box-->
												</div><!--/.col-->

												<div class="col-lg-2 col-md-1 col-sm-4">
													<div class="single-tab-select-box">
														<h2>duration</h2>
														<div class="travel-select-icon">
															<select class="form-control ">

															  	<option value="default">5</option><!-- /.option-->

															  	<option value="10">10</option><!-- /.option-->

															  	<option value="15">15</option><!-- /.option-->
															  	<option value="20">20</option><!-- /.option-->

															</select><!-- /.select-->
														</div><!-- /.travel-select-icon -->
													</div><!--/.single-tab-select-box-->
												</div><!--/.col-->

												<div class="col-lg-2 col-md-1 col-sm-4">
													<div class="single-tab-select-box">
														<h2>members</h2>
														<div class="travel-select-icon">
															<select class="form-control ">

															  	<option value="default">1</option><!-- /.option-->

															  	<option value="2">2</option><!-- /.option-->

															  	<option value="4">4</option><!-- /.option-->
															  	<option value="8">8</option><!-- /.option-->

															</select><!-- /.select-->
														</div><!-- /.travel-select-icon -->
													</div><!--/.single-tab-select-box-->
												</div><!--/.col-->

											</div><!--/.row-->

											<div class="row">
												<div class="col-sm-5"></div><!--/.col-->
												<div class="clo-sm-7">
													<div class="about-btn travel-mrt-0 pull-right">
														<button  class="about-view travel-btn">
															Submit	
														</button><!--/.travel-btn-->
													</div><!--/.about-btn-->
												</div><!--/.col-->

											</div><!--/.row-->

										</div><!--/.tab-para-->

									</div><!--/.tabpannel-->

									<div role="tabpanel" class="tab-pane fade in" id="flights">
										<div class="tab-para">
											<div class="trip-circle">
												<div class="single-trip-circle">
													<input type="radio" id="radio01" name="radio" />
  													<label for="radio01">
  														<span class="round-boarder">
  															<span class="round-boarder1"></span>
  														</span>round trip
  													</label>
												</div><!--/.single-trip-circle-->
												<div class="single-trip-circle">
													<input type="radio" id="radio02" name="radio" />
  													<label for="radio02">
  														<span class="round-boarder">
  															<span class="round-boarder1"></span>
  														</span>on way
  													</label>
												</div><!--/.single-trip-circle-->
											</div><!--/.trip-circle-->
											<div class="row">
												<div class="col-lg-4 col-md-4 col-sm-12">
													<div class="single-tab-select-box">

														<h2>from</h2>

														<div class="travel-select-icon">
															<select class="form-control ">

															  	<option value="default">enter your location</option><!-- /.option-->

															  	<option value="turkey">turkey</option><!-- /.option-->

															  	<option value="russia">russia</option><!-- /.option-->
															  	<option value="egept">egypt</option><!-- /.option-->

															</select><!-- /.select-->
														</div><!-- /.travel-select-icon -->
													</div><!--/.single-tab-select-box-->
												</div><!--/.col-->

												<div class="col-lg-2 col-md-3 col-sm-4">
													<div class="single-tab-select-box">
														<h2>departure</h2>
														<div class="travel-check-icon">
															<form action="#">
																<input type="text" name="departure" class="form-control" data-toggle="datepicker"
																placeholder="12 -01 - 2017 "/>
															</form>
														</div><!-- /.travel-check-icon -->
													</div><!--/.single-tab-select-box-->
												</div><!--/.col-->

												<div class="col-lg-2 col-md-3 col-sm-4">
													<div class="single-tab-select-box">
														<h2>return</h2>
														<div class="travel-check-icon">
															<form action="#">
																<input type="text" name="return" class="form-control" data-toggle="datepicker" placeholder="22 -01 - 2017 "/>
															</form>
														</div><!-- /.travel-check-icon -->
													</div><!--/.single-tab-select-box-->
												</div><!--/.col-->

												<div class="col-lg-2 col-md-1 col-sm-4">
													<div class="single-tab-select-box">
														<h2>adults</h2>
														<div class="travel-select-icon">
															<select class="form-control ">

															  	<option value="default">5</option><!-- /.option-->

															  	<option value="10">10</option><!-- /.option-->

															  	<option value="15">15</option><!-- /.option-->
															  	<option value="20">20</option><!-- /.option-->

															</select><!-- /.select-->
														</div><!-- /.travel-select-icon -->
													</div><!--/.single-tab-select-box-->
												</div><!--/.col-->

												<div class="col-lg-2 col-md-1 col-sm-4">
													<div class="single-tab-select-box">
														<h2>childs</h2>
														<div class="travel-select-icon">
															<select class="form-control ">

															  	<option value="default">1</option><!-- /.option-->

															  	<option value="2">2</option><!-- /.option-->

															  	<option value="4">4</option><!-- /.option-->
															  	<option value="8">8</option><!-- /.option-->

															</select><!-- /.select-->
														</div><!-- /.travel-select-icon -->
													</div><!--/.single-tab-select-box-->
												</div><!--/.col-->

											</div><!--/.row-->

											<div class="row">
												<div class="col-lg-4 col-md-4 col-sm-12">
													<div class="single-tab-select-box">

														<div class="travel-select-icon">
														    <input type="password" class="form-control" placeholder="Enter your Password Here"/>
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
        		</div><!--/.row-->
        	</div><!--/.container-->

        </section><!--/.travel-box-->
		<!--travel-box end-->














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
