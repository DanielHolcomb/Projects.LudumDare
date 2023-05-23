﻿using System.Text.Json.Serialization;

namespace Projects.LudumDare.Models
{

    public class GameData
    {
        [JsonPropertyName("status")]
        public int Status { get; set; }

        [JsonPropertyName("caller_id")]
        public int CallerId { get; set; }

        [JsonPropertyName("nodes_cached")]
        public List<object> NodesCached { get; set; }

        [JsonPropertyName("node")]
        public List<Node> Node { get; set; }
    }

    public class File
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("author")]
        public int Author { get; set; }

        [JsonPropertyName("node")]
        public int Node { get; set; }

        [JsonPropertyName("tag")]
        public int Tag { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("size")]
        public int Size { get; set; }

        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonPropertyName("status")]
        public int Status { get; set; }
    }

    public class Grade
    {
        [JsonPropertyName("grade-01")]
        public int Grade01 { get; set; }

        [JsonPropertyName("grade-02")]
        public int Grade02 { get; set; }

        [JsonPropertyName("grade-03")]
        public int Grade03 { get; set; }

        [JsonPropertyName("grade-04")]
        public int Grade04 { get; set; }

        [JsonPropertyName("grade-05")]
        public int Grade05 { get; set; }

        [JsonPropertyName("grade-06")]
        public int Grade06 { get; set; }

        [JsonPropertyName("grade-07")]
        public int Grade07 { get; set; }

        [JsonPropertyName("grade-08")]
        public int Grade08 { get; set; }
    }

    public class Magic
    {
        [JsonPropertyName("cool")]
        public double Cool { get; set; }

        [JsonPropertyName("feedback")]
        public int Feedback { get; set; }

        [JsonPropertyName("given")]
        public double Given { get; set; }

        [JsonPropertyName("grade")]
        public double Grade { get; set; }

        [JsonPropertyName("grade-01-average")]
        public double Grade01Average { get; set; }

        [JsonPropertyName("grade-01-result")]
        public int Grade01Result { get; set; }

        [JsonPropertyName("grade-02-average")]
        public double Grade02Average { get; set; }

        [JsonPropertyName("grade-02-result")]
        public int Grade02Result { get; set; }

        [JsonPropertyName("grade-03-average")]
        public double Grade03Average { get; set; }

        [JsonPropertyName("grade-03-result")]
        public int Grade03Result { get; set; }

        [JsonPropertyName("grade-04-average")]
        public double Grade04Average { get; set; }

        [JsonPropertyName("grade-04-result")]
        public int Grade04Result { get; set; }

        [JsonPropertyName("grade-05-average")]
        public double Grade05Average { get; set; }

        [JsonPropertyName("grade-05-result")]
        public int Grade05Result { get; set; }

        [JsonPropertyName("grade-06-average")]
        public double Grade06Average { get; set; }

        [JsonPropertyName("grade-06-result")]
        public int Grade06Result { get; set; }

        [JsonPropertyName("grade-07-average")]
        public double Grade07Average { get; set; }

        [JsonPropertyName("grade-08-average")]
        public double Grade08Average { get; set; }

        [JsonPropertyName("grade-08-result")]
        public int Grade08Result { get; set; }

        [JsonPropertyName("smart")]
        public double Smart { get; set; }

        [JsonPropertyName("grade-07-result")]
        public int? Grade07Result { get; set; }
    }

    public class Meta
    {
        [JsonPropertyName("author")]
        public List<int> Author { get; set; }

        [JsonPropertyName("link-01")]
        public string Link01 { get; set; }

        [JsonPropertyName("link-01-tag")]
        public List<int> Link01Tag { get; set; }

        [JsonPropertyName("cover")]
        public string Cover { get; set; }

        [JsonPropertyName("link-02")]
        public string Link02 { get; set; }

        [JsonPropertyName("link-02-tag")]
        public List<int> Link02Tag { get; set; }

        [JsonPropertyName("link-03")]
        public string Link03 { get; set; }

        [JsonPropertyName("link-03-tag")]
        public List<int> Link03Tag { get; set; }

        [JsonPropertyName("grade-07-out")]
        public string Grade07Out { get; set; }

        [JsonPropertyName("grade-06-out")]
        public string Grade06Out { get; set; }

        [JsonPropertyName("grade-05-out")]
        public string Grade05Out { get; set; }

        [JsonPropertyName("allow-anonymous-comments")]
        public string AllowAnonymousComments { get; set; }

        [JsonPropertyName("link-02-name")]
        public string Link02Name { get; set; }

        [JsonPropertyName("link-03-name")]
        public string Link03Name { get; set; }

        [JsonPropertyName("link-01-name")]
        public string Link01Name { get; set; }
    }

    public class Node
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("parent")]
        public int Parent { get; set; }

        [JsonPropertyName("superparent")]
        public int Superparent { get; set; }

        [JsonPropertyName("author")]
        public int Author { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("subtype")]
        public string Subtype { get; set; }

        [JsonPropertyName("subsubtype")]
        public string Subsubtype { get; set; }

        [JsonPropertyName("published")]
        public DateTime Published { get; set; }

        [JsonPropertyName("created")]
        public DateTime Created { get; set; }

        [JsonPropertyName("modified")]
        public DateTime Modified { get; set; }

        [JsonPropertyName("version")]
        public int Version { get; set; }

        [JsonPropertyName("slug")]
        public string Slug { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("body")]
        public string Body { get; set; }

        [JsonPropertyName("scope")]
        public string Scope { get; set; }

        [JsonPropertyName("node-timestamp")]
        public DateTime NodeTimestamp { get; set; }

        [JsonPropertyName("meta")]
        public Meta Meta { get; set; }

        [JsonPropertyName("meta-timestamp")]
        public DateTime MetaTimestamp { get; set; }

        [JsonPropertyName("path")]
        public string Path { get; set; }

        [JsonPropertyName("parents")]
        public List<int> Parents { get; set; }

        [JsonPropertyName("files")]
        public List<File> Files { get; set; }

        [JsonPropertyName("files-timestamp")]
        public object FilesTimestamp { get; set; }

        [JsonPropertyName("love")]
        public int Love { get; set; }

        [JsonPropertyName("comments")]
        public int Comments { get; set; }

        [JsonPropertyName("comments-timestamp")]
        public DateTime CommentsTimestamp { get; set; }

        [JsonPropertyName("grade")]
        public Grade Grade { get; set; }

        [JsonPropertyName("magic")]
        public Magic Magic { get; set; }

        [JsonPropertyName("eventStats")]
        public EventStats EventStats { get; set; }

        [JsonPropertyName("edition")]
        public int Edition { get; set; }
    }
}
