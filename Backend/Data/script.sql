USE [master]
GO
/****** Object:  Database [Movies]    Script Date: 2/20/2025 6:48:21 PM ******/
CREATE DATABASE [Movies]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Movies', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Movies.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Movies_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Movies_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Movies] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Movies].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Movies] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Movies] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Movies] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Movies] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Movies] SET ARITHABORT OFF 
GO
ALTER DATABASE [Movies] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Movies] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Movies] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Movies] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Movies] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Movies] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Movies] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Movies] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Movies] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Movies] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Movies] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Movies] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Movies] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Movies] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Movies] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Movies] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Movies] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Movies] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Movies] SET  MULTI_USER 
GO
ALTER DATABASE [Movies] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Movies] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Movies] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Movies] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Movies] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Movies] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Movies] SET QUERY_STORE = ON
GO
ALTER DATABASE [Movies] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Movies]
GO
/****** Object:  Table [dbo].[MovieSeriesTags]    Script Date: 2/20/2025 6:48:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MovieSeriesTags](
	[movie_series_id] [int] NOT NULL,
	[tag_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[movie_series_id] ASC,
	[tag_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MoviesSeries]    Script Date: 2/20/2025 6:48:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MoviesSeries](
	[movie_series_id] [int] IDENTITY(1,1) NOT NULL,
	[title] [varchar](100) NOT NULL,
	[genre] [varchar](50) NULL,
	[release_date] [date] NULL,
	[description] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[movie_series_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ratings]    Script Date: 2/20/2025 6:48:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ratings](
	[rating_id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NOT NULL,
	[movie_series_id] [int] NOT NULL,
	[rating] [decimal](3, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[rating_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reviews]    Script Date: 2/20/2025 6:48:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reviews](
	[review_id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NOT NULL,
	[movie_series_id] [int] NOT NULL,
	[review_text] [text] NULL,
	[review_date] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[review_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tags]    Script Date: 2/20/2025 6:48:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tags](
	[tag_id] [int] IDENTITY(1,1) NOT NULL,
	[tag_name] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[tag_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 2/20/2025 6:48:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[user_id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NOT NULL,
	[email] [varchar](100) NOT NULL,
	[created_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[MovieSeriesTags] ([movie_series_id], [tag_id]) VALUES (1, 1)
INSERT [dbo].[MovieSeriesTags] ([movie_series_id], [tag_id]) VALUES (1, 3)
INSERT [dbo].[MovieSeriesTags] ([movie_series_id], [tag_id]) VALUES (2, 1)
INSERT [dbo].[MovieSeriesTags] ([movie_series_id], [tag_id]) VALUES (2, 2)
INSERT [dbo].[MovieSeriesTags] ([movie_series_id], [tag_id]) VALUES (3, 1)
GO
SET IDENTITY_INSERT [dbo].[MoviesSeries] ON 

INSERT [dbo].[MoviesSeries] ([movie_series_id], [title], [genre], [release_date], [description]) VALUES (1, N'Inception', N'Sci-Fi', CAST(N'2010-07-16' AS Date), N'A mind-bending thriller about dream invasion.')
INSERT [dbo].[MoviesSeries] ([movie_series_id], [title], [genre], [release_date], [description]) VALUES (2, N'The Matrix', N'Sci-Fi', CAST(N'1999-03-31' AS Date), N'A computer hacker learns about the true nature of reality.')
INSERT [dbo].[MoviesSeries] ([movie_series_id], [title], [genre], [release_date], [description]) VALUES (3, N'Interstellar', N'Sci-Fi', CAST(N'2014-11-07' AS Date), N'A team of explorers travel through a wormhole in space.')
SET IDENTITY_INSERT [dbo].[MoviesSeries] OFF
GO
SET IDENTITY_INSERT [dbo].[Ratings] ON 

INSERT [dbo].[Ratings] ([rating_id], [user_id], [movie_series_id], [rating]) VALUES (1, 1, 1, CAST(9.50 AS Decimal(3, 2)))
INSERT [dbo].[Ratings] ([rating_id], [user_id], [movie_series_id], [rating]) VALUES (2, 2, 1, CAST(9.00 AS Decimal(3, 2)))
INSERT [dbo].[Ratings] ([rating_id], [user_id], [movie_series_id], [rating]) VALUES (3, 1, 2, CAST(8.50 AS Decimal(3, 2)))
INSERT [dbo].[Ratings] ([rating_id], [user_id], [movie_series_id], [rating]) VALUES (4, 3, 3, CAST(9.00 AS Decimal(3, 2)))
INSERT [dbo].[Ratings] ([rating_id], [user_id], [movie_series_id], [rating]) VALUES (5, 2, 3, CAST(8.00 AS Decimal(3, 2)))
SET IDENTITY_INSERT [dbo].[Ratings] OFF
GO
SET IDENTITY_INSERT [dbo].[Reviews] ON 

INSERT [dbo].[Reviews] ([review_id], [user_id], [movie_series_id], [review_text], [review_date]) VALUES (1, 1, 1, N'Amazing movie with a complex plot!', CAST(N'2025-02-20T18:45:50.820' AS DateTime))
INSERT [dbo].[Reviews] ([review_id], [user_id], [movie_series_id], [review_text], [review_date]) VALUES (2, 2, 1, N'Mind blowing experience!', CAST(N'2025-02-20T18:45:50.820' AS DateTime))
INSERT [dbo].[Reviews] ([review_id], [user_id], [movie_series_id], [review_text], [review_date]) VALUES (3, 1, 2, N'A revolutionary sci-fi film.', CAST(N'2025-02-20T18:45:50.820' AS DateTime))
INSERT [dbo].[Reviews] ([review_id], [user_id], [movie_series_id], [review_text], [review_date]) VALUES (4, 3, 3, N'A deep, thought-provoking experience.', CAST(N'2025-02-20T18:45:50.820' AS DateTime))
SET IDENTITY_INSERT [dbo].[Reviews] OFF
GO
SET IDENTITY_INSERT [dbo].[Tags] ON 

INSERT [dbo].[Tags] ([tag_id], [tag_name]) VALUES (2, N'Action')
INSERT [dbo].[Tags] ([tag_id], [tag_name]) VALUES (1, N'Sci-Fi')
INSERT [dbo].[Tags] ([tag_id], [tag_name]) VALUES (3, N'Thriller')
SET IDENTITY_INSERT [dbo].[Tags] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([user_id], [username], [email], [created_at]) VALUES (1, N'john_doe', N'john@example.com', CAST(N'2025-02-20T18:45:50.807' AS DateTime))
INSERT [dbo].[Users] ([user_id], [username], [email], [created_at]) VALUES (2, N'jane_smith', N'jane@example.com', CAST(N'2025-02-20T18:45:50.807' AS DateTime))
INSERT [dbo].[Users] ([user_id], [username], [email], [created_at]) VALUES (3, N'alice', N'alice@example.com', CAST(N'2025-02-20T18:45:50.807' AS DateTime))
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Tags__E298655C9C6A8770]    Script Date: 2/20/2025 6:48:21 PM ******/
ALTER TABLE [dbo].[Tags] ADD UNIQUE NONCLUSTERED 
(
	[tag_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Users__AB6E6164907A46F0]    Script Date: 2/20/2025 6:48:21 PM ******/
ALTER TABLE [dbo].[Users] ADD UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Reviews] ADD  DEFAULT (getdate()) FOR [review_date]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[MovieSeriesTags]  WITH CHECK ADD FOREIGN KEY([movie_series_id])
REFERENCES [dbo].[MoviesSeries] ([movie_series_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MovieSeriesTags]  WITH CHECK ADD FOREIGN KEY([tag_id])
REFERENCES [dbo].[Tags] ([tag_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Ratings]  WITH CHECK ADD FOREIGN KEY([movie_series_id])
REFERENCES [dbo].[MoviesSeries] ([movie_series_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Ratings]  WITH CHECK ADD FOREIGN KEY([user_id])
REFERENCES [dbo].[Users] ([user_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Reviews]  WITH CHECK ADD FOREIGN KEY([movie_series_id])
REFERENCES [dbo].[MoviesSeries] ([movie_series_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Reviews]  WITH CHECK ADD FOREIGN KEY([user_id])
REFERENCES [dbo].[Users] ([user_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Ratings]  WITH CHECK ADD CHECK  (([rating]>=(0) AND [rating]<=(10)))
GO
/****** Object:  StoredProcedure [dbo].[AddReview]    Script Date: 2/20/2025 6:48:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Stored Procedure: Thêm một review mới
CREATE PROCEDURE [dbo].[AddReview]
    @user_id INT,
    @movie_series_id INT,
    @review_text TEXT
AS
BEGIN
    INSERT INTO Reviews (user_id, movie_series_id, review_text, review_date)
    VALUES (@user_id, @movie_series_id, @review_text, GETDATE());
END;
GO
/****** Object:  StoredProcedure [dbo].[GetMovieReviews]    Script Date: 2/20/2025 6:48:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure: Lấy danh sách review cho một phim/series cụ thể
CREATE PROCEDURE [dbo].[GetMovieReviews]
    @movie_series_id INT
AS
BEGIN
    SELECT r.review_id, r.user_id, u.username, r.review_text, r.review_date
    FROM Reviews r
    JOIN Users u ON r.user_id = u.user_id
    WHERE r.movie_series_id = @movie_series_id
    ORDER BY r.review_date DESC;
END;
GO
/****** Object:  StoredProcedure [dbo].[GetMoviesByTag]    Script Date: 2/20/2025 6:48:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Stored Procedure: Lấy danh sách phim/series theo tag
CREATE PROCEDURE [dbo].[GetMoviesByTag]
    @tag_name VARCHAR(50)
AS
BEGIN
    SELECT ms.movie_series_id, ms.title, ms.genre, ms.release_date
    FROM MoviesSeries ms
    JOIN MovieSeriesTags mst ON ms.movie_series_id = mst.movie_series_id
    JOIN Tags t ON mst.tag_id = t.tag_id
    WHERE t.tag_name = @tag_name;
END;
GO
/****** Object:  StoredProcedure [dbo].[GetTopRatedMovies]    Script Date: 2/20/2025 6:48:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Stored Procedure: Lấy danh sách phim/series có xếp hạng cao nhất
CREATE PROCEDURE [dbo].[GetTopRatedMovies]
    @top_count INT
AS
BEGIN
    SELECT ms.movie_series_id, ms.title, AVG(r.rating) AS avg_rating
    FROM MoviesSeries ms
    JOIN Ratings r ON ms.movie_series_id = r.movie_series_id
    GROUP BY ms.movie_series_id, ms.title
    ORDER BY avg_rating DESC
    OFFSET 0 ROWS FETCH NEXT @top_count ROWS ONLY;
END;
GO
USE [master]
GO
ALTER DATABASE [Movies] SET  READ_WRITE 
GO
