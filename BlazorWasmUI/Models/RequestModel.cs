using PostmanCloneLibrary;
using System.ComponentModel.DataAnnotations;

namespace BlazorWasmUI.Models;

public class RequestModel
{
	[Required]
    [Display(Name = "Http Verb Type")]
	public HttpAction? HttpVerbSelection { get; set; }

    [Required]
    [Url]
    [Display(Name = "API Url")]
    public string? ApiText { get; set; }
    public string Body { get; set; } = "";
}
