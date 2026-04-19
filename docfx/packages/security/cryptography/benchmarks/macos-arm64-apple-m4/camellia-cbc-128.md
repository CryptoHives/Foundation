| Description                                     | TestDataSize | Mean         | Error        | StdDev       | Allocated |
|------------------------------------------------ |------------- |-------------:|-------------:|-------------:|----------:|
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128B         |     590.9 ns |      2.68 ns |      2.38 ns |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 128B         |     905.5 ns |      2.49 ns |      2.21 ns |     576 B |
|                                                 |              |              |              |              |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128B         |     649.1 ns |      1.54 ns |      1.29 ns |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 128B         |     911.1 ns |     10.65 ns |      8.89 ns |     576 B |
|                                                 |              |              |              |              |           |
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 1KB          |   4,179.5 ns |     18.40 ns |     16.32 ns |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 1KB          |   5,846.5 ns |      9.77 ns |      8.66 ns |    2816 B |
|                                                 |              |              |              |              |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 1KB          |   4,760.4 ns |     44.73 ns |     39.66 ns |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 1KB          |   5,959.5 ns |     16.92 ns |     13.21 ns |    2816 B |
|                                                 |              |              |              |              |           |
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 8KB          |  33,431.6 ns |    507.17 ns |    563.72 ns |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 8KB          |  45,668.1 ns |    453.61 ns |    424.31 ns |   20736 B |
|                                                 |              |              |              |              |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 8KB          |  37,693.0 ns |    209.48 ns |    195.95 ns |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 8KB          |  45,668.4 ns |    182.61 ns |    142.57 ns |   20736 B |
|                                                 |              |              |              |              |           |
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128KB        | 526,228.0 ns |  1,946.47 ns |  1,625.39 ns |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 128KB        | 759,503.4 ns | 15,059.95 ns | 27,537.97 ns |  327936 B |
|                                                 |              |              |              |              |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128KB        | 606,558.0 ns |  3,336.54 ns |  2,786.16 ns |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 128KB        | 727,640.7 ns |  1,858.36 ns |  1,551.82 ns |  327936 B |