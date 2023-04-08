<Query Kind="Program">
  <Namespace>BenchmarkDotNet.Attributes</Namespace>
  <RuntimeVersion>7.0</RuntimeVersion>
</Query>

#load "BenchmarkDotNet"

private Regex _regex;
private Regex _compiledRegex;
private const string Pattern = @"(?<=\().*?(?=\))";
private const string Input = @"<p>text</p><p>text</p><p>text</p><p>text</p><p>text</p><p>text</p><p>text</p><p>text</p><p>text</p><p>text</p><p>text</p><p>text</p><p>text</p><p>text</p><p>text</p>";

void Main()
{
	RunBenchmark(); return;
}

[Benchmark]
public void Static()
{
	_ = Regex.IsMatch(Input, Pattern);
}

[Benchmark]
public void StaticCompiled()
{
	_ = Regex.IsMatch(Input, Pattern, RegexOptions.Compiled);
}

[Benchmark]
public void Instance()
{
	_ = _regex.IsMatch(Input);
}

[Benchmark]
public void InstanceCompiled()
{
	_ = _compiledRegex.IsMatch(Input);
}


[GlobalSetup]
public void BenchmarkSetup()
{
	_regex = new Regex(@"(?<=\().*?(?=\))");
	_compiledRegex = new Regex(@"(?<=\().*?(?=\))", RegexOptions.Compiled);
}