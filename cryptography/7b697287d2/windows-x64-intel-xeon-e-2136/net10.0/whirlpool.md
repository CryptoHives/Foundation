| Description                                     | TestDataSize | Mean         | Error      | StdDev     | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|-----------:|-----------:|----------:|----------:|
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 128B         |     2.078 μs |  0.0374 μs |  0.0350 μs |   3,278 B |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 128B         |     3.430 μs |  0.0515 μs |  0.0482 μs |  25,629 B |    6336 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 128B         |     9.710 μs |  0.1434 μs |  0.1341 μs |   8,163 B |      56 B |
|                                                 |              |              |            |            |           |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 137B         |     2.074 μs |  0.0404 μs |  0.0378 μs |   3,288 B |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 137B         |     3.437 μs |  0.0447 μs |  0.0418 μs |  24,597 B |    6328 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 137B         |     8.763 μs |  0.0788 μs |  0.0737 μs |   8,155 B |      56 B |
|                                                 |              |              |            |            |           |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 1KB          |    11.624 μs |  0.1873 μs |  0.1752 μs |   3,278 B |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 1KB          |    17.473 μs |  0.2553 μs |  0.2388 μs |  24,495 B |   12032 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 1KB          |    61.072 μs |  0.8382 μs |  0.7840 μs |   8,163 B |      56 B |
|                                                 |              |              |            |            |           |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 1025B        |    11.608 μs |  0.1999 μs |  0.1870 μs |   3,293 B |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 1025B        |    17.472 μs |  0.2793 μs |  0.2612 μs |  24,795 B |   12040 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 1025B        |    53.510 μs |  0.6827 μs |  0.6386 μs |   8,155 B |      56 B |
|                                                 |              |              |            |            |           |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 8KB          |    87.841 μs |  1.1466 μs |  1.0725 μs |   3,278 B |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 8KB          |   128.815 μs |  1.9341 μs |  1.8092 μs |  24,887 B |   58636 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 8KB          |   409.155 μs |  7.1263 μs |  6.6660 μs |   8,155 B |      56 B |
|                                                 |              |              |            |            |           |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 128KB        | 1,394.146 μs | 22.2462 μs | 20.8091 μs |   3,288 B |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 128KB        | 2,108.523 μs | 35.9100 μs | 33.5902 μs |  24,875 B |  857370 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 128KB        | 6,527.882 μs | 85.9022 μs | 80.3530 μs |   8,155 B |      56 B |