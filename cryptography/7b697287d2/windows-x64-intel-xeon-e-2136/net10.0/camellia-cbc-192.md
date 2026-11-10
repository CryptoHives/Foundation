| Description                                     | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128B         |     1.344 μs | 0.0017 μs | 0.0014 μs |   1,311 B |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 128B         |     2.354 μs | 0.0027 μs | 0.0024 μs |   2,935 B |     584 B |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128B         |     1.626 μs | 0.0008 μs | 0.0007 μs |   1,307 B |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 128B         |     2.182 μs | 0.0060 μs | 0.0056 μs |   2,933 B |     584 B |
|                                                 |              |              |           |           |           |           |
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 1KB          |     9.428 μs | 0.0065 μs | 0.0051 μs |   1,311 B |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 1KB          |    15.539 μs | 0.0275 μs | 0.0257 μs |   2,933 B |    2824 B |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 1KB          |    11.483 μs | 0.0067 μs | 0.0059 μs |   1,313 B |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 1KB          |    14.965 μs | 0.0388 μs | 0.0363 μs |   2,931 B |    2824 B |
|                                                 |              |              |           |           |           |           |
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 8KB          |    73.283 μs | 0.0763 μs | 0.0714 μs |   1,311 B |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 8KB          |   119.944 μs | 0.2244 μs | 0.2099 μs |   2,935 B |   20744 B |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 8KB          |    90.004 μs | 0.1424 μs | 0.1332 μs |   1,313 B |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 8KB          |   111.312 μs | 0.4352 μs | 0.4071 μs |   2,933 B |   20744 B |
|                                                 |              |              |           |           |           |           |
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128KB        | 1,175.027 μs | 0.4874 μs | 0.4070 μs |   1,311 B |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 128KB        | 1,904.611 μs | 2.7363 μs | 2.4256 μs |   2,935 B |  327944 B |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128KB        | 1,437.095 μs | 0.6490 μs | 0.5067 μs |   1,313 B |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 128KB        | 1,882.404 μs | 3.5074 μs | 3.2808 μs |   2,935 B |  327944 B |