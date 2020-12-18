API_KEY=$1

if [ -z "$API_KEY" ]; then
	echo "Please specify an api key"
	exit 1;
fi

for i in $(find dist/Scanbot.Xamarin.*); do
	echo "Uploading..."
	nuget push $i -ApiKey $API_KEY -Timeout 600 -Source nuget.org
done
