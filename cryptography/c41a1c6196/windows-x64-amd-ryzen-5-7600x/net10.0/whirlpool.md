| Description                                     | TestDataSize | Mean         | Error      | StdDev     | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|-----------:|-----------:|----------:|----------:|
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 128B         |     1.539 μs |  0.0229 μs |  0.0214 μs |   3,242 B |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 128B         |     2.387 μs |  0.0474 μs |  0.0443 μs |  24,342 B |    6336 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 128B         |     5.825 μs |  0.0217 μs |  0.0181 μs |   8,097 B |      56 B |
|                                                 |              |              |            |            |           |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 137B         |     1.544 μs |  0.0078 μs |  0.0069 μs |   3,248 B |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 137B         |     2.371 μs |  0.0206 μs |  0.0182 μs |  24,375 B |    6328 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 137B         |     5.820 μs |  0.0172 μs |  0.0161 μs |   8,105 B |      56 B |
|                                                 |              |              |            |            |           |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 1KB          |     8.769 μs |  0.1045 μs |  0.0978 μs |   3,242 B |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 1KB          |    12.123 μs |  0.2048 μs |  0.1916 μs |  24,392 B |   12032 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 1KB          |    36.718 μs |  0.2744 μs |  0.2433 μs |   8,097 B |      56 B |
|                                                 |              |              |            |            |           |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 1025B        |     8.978 μs |  0.0192 μs |  0.0170 μs |   3,253 B |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 1025B        |    12.172 μs |  0.1831 μs |  0.1712 μs |  24,776 B |   12040 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 1025B        |    35.899 μs |  0.1155 μs |  0.0964 μs |   8,108 B |      56 B |
|                                                 |              |              |            |            |           |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 8KB          |    65.613 μs |  0.2834 μs |  0.2367 μs |   3,242 B |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 8KB          |    88.522 μs |  0.5712 μs |  0.5343 μs |  24,858 B |   58624 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 8KB          |   280.584 μs |  2.8003 μs |  2.6194 μs |   8,097 B |      56 B |
|                                                 |              |              |            |            |           |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 128KB        | 1,052.168 μs | 13.8848 μs | 12.3085 μs |   3,252 B |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 128KB        | 1,465.535 μs | 11.1018 μs |  9.2705 μs |  24,775 B |  857372 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 128KB        | 4,419.690 μs | 55.2044 μs | 46.0982 μs |   8,105 B |      56 B |