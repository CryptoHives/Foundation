| Description                                     | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 128B         |     2.734 μs |   0.0025 μs |   0.0024 μs |   3,278 B |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 128B         |     4.484 μs |   0.0064 μs |   0.0057 μs |  24,586 B |    6336 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 128B         |    11.682 μs |   0.1300 μs |   0.1152 μs |   8,158 B |      56 B |
|                                                 |              |              |             |             |           |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 137B         |     2.731 μs |   0.0026 μs |   0.0024 μs |   3,288 B |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 137B         |     4.493 μs |   0.0108 μs |   0.0101 μs |  24,504 B |    6328 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 137B         |    11.533 μs |   0.0864 μs |   0.0808 μs |   8,155 B |      56 B |
|                                                 |              |              |             |             |           |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 1KB          |    15.275 μs |   0.0037 μs |   0.0035 μs |   3,278 B |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 1KB          |    22.780 μs |   0.0219 μs |   0.0194 μs |  24,491 B |   12032 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 1KB          |    81.013 μs |   0.6139 μs |   0.4793 μs |   8,185 B |      56 B |
|                                                 |              |              |             |             |           |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 1025B        |    15.248 μs |   0.0047 μs |   0.0044 μs |   3,293 B |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 1025B        |    22.392 μs |   0.0201 μs |   0.0168 μs |  24,752 B |   12040 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 1025B        |    82.303 μs |   1.5909 μs |   1.7682 μs |   8,185 B |      56 B |
|                                                 |              |              |             |             |           |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 8KB          |   115.305 μs |   0.0421 μs |   0.0394 μs |   3,289 B |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 8KB          |   167.919 μs |   0.2042 μs |   0.1910 μs |  24,887 B |   58624 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 8KB          |   626.336 μs |   6.2621 μs |   5.5512 μs |   8,163 B |      56 B |
|                                                 |              |              |             |             |           |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 128KB        | 1,837.010 μs |   0.2728 μs |   0.2551 μs |   3,288 B |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 128KB        | 2,760.162 μs |   2.2360 μs |   1.9822 μs |  24,878 B |  857370 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 128KB        | 9,964.638 μs | 126.8870 μs | 112.4820 μs |   8,163 B |      56 B |