using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace WebApplication1.Controller
{
	[ApiController]
	[Route("[controller]")]
	public class SearchController : ControllerBase
	{
		private readonly ISearchService _searchService;

		public SearchController(ISearchService searchService)
		{
			_searchService = searchService;
		}

		[HttpGet]
		public ActionResult<IEnumerable<SearchResult>> Get(string query)
		{
			var results = _searchService.Search(query);
			return Ok(results);
		}
	}

}
