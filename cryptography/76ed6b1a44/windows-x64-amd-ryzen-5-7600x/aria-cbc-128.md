| Description                                 | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|-------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128B         |     1.422 μs | 0.0086 μs | 0.0080 μs |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 128B         |     2.444 μs | 0.0101 μs | 0.0094 μs |    1288 B |
|                                             |              |              |           |           |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128B         |     1.421 μs | 0.0075 μs | 0.0070 μs |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 128B         |     2.341 μs | 0.0131 μs | 0.0122 μs |    1288 B |
|                                             |              |              |           |           |           |
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 1KB          |    10.154 μs | 0.0579 μs | 0.0513 μs |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 1KB          |    15.058 μs | 0.0889 μs | 0.0831 μs |    3528 B |
|                                             |              |              |           |           |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 1KB          |    10.184 μs | 0.0564 μs | 0.0500 μs |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 1KB          |    15.249 μs | 0.0883 μs | 0.0782 μs |    3528 B |
|                                             |              |              |           |           |           |
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 8KB          |    79.852 μs | 0.4395 μs | 0.3896 μs |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 8KB          |   115.970 μs | 0.2453 μs | 0.2049 μs |   21448 B |
|                                             |              |              |           |           |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 8KB          |    80.031 μs | 0.2939 μs | 0.2605 μs |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 8KB          |   117.629 μs | 0.5000 μs | 0.3904 μs |   21448 B |
|                                             |              |              |           |           |           |
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128KB        | 1,276.930 μs | 7.1693 μs | 6.3554 μs |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 128KB        | 1,850.668 μs | 6.4922 μs | 6.0728 μs |  328648 B |
|                                             |              |              |           |           |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128KB        | 1,282.683 μs | 9.6670 μs | 8.5695 μs |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 128KB        | 1,873.519 μs | 5.8244 μs | 5.4482 μs |  328648 B |