
require 'albacore'

Albacore.configure do |config|
    config.log_level = :verbose
end

task :default => [:build, :unittests]

msbuild :build do |msb|
  msb.solution = "CardGames.sln"
	msb.targets :build
  msb.properties :configuration => :debug
end

nunit :unittests do |nunit|
  nunit.command = "packages/NUnit.Runners.2.6.4/tools/nunit-console.exe"
  nunit.assemblies "TexasHoldemTests/bin/debug/TexasHoldemTests.dll"
end
