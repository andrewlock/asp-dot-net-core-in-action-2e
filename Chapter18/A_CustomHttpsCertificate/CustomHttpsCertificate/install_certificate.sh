#Install the cert utils
sudo apt install libnss3-tools
#Generate the certificate
openssl req -config localhost.conf -new -x509 -sha256 -newkey rsa:2048 -nodes \
    -keyout localhost.key -days 3650 -out localhost.crt
#Create the pfx file
openssl pkcs12 -export -out localhost.pfx -inkey localhost.key -in localhost.crt
# Trust the certificate for SSL 
pk12util -d sql:$HOME/.pki/nssdb -i localhost.pfx
# Trust a self-signed server certificate
certutil -d sql:$HOME/.pki/nssdb -A -t "P,," -n 'dev cert' -i localhost.crt