| Description                                  | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|--------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| AbsorbSqueeze · BLAKE3 · CryptoHives-Ssse3   | 128B         |     1.662 μs | 0.0009 μs | 0.0008 μs |  17,688 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX2    | 128B         |     1.670 μs | 0.0008 μs | 0.0008 μs |  15,744 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX512F | 128B         |     1.687 μs | 0.0009 μs | 0.0008 μs |  22,269 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native   | 128B         |     1.756 μs | 0.0009 μs | 0.0008 μs |     970 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed      | 128B         |     1.807 μs | 0.0010 μs | 0.0009 μs |  30,858 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed  | 128B         |     2.389 μs | 0.0012 μs | 0.0010 μs |  15,708 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar  | 128B         |     2.899 μs | 0.0063 μs | 0.0056 μs |  25,688 B |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle        | 128B         |    21.793 μs | 0.0632 μs | 0.0561 μs |  33,802 B |      56 B |
|                                              |              |              |           |           |           |           |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX512F | 1KB          |     1.722 μs | 0.0009 μs | 0.0009 μs |  22,753 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX2    | 1KB          |     1.754 μs | 0.0011 μs | 0.0009 μs |  22,274 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed      | 1KB          |     1.863 μs | 0.0011 μs | 0.0010 μs |  31,035 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Ssse3   | 1KB          |     2.268 μs | 0.0017 μs | 0.0016 μs |  17,278 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native   | 1KB          |     2.381 μs | 0.0013 μs | 0.0012 μs |     970 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed  | 1KB          |     3.075 μs | 0.0022 μs | 0.0019 μs |   9,555 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar  | 1KB          |     4.110 μs | 0.0444 μs | 0.0415 μs |  25,498 B |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle        | 1KB          |    31.518 μs | 0.0630 μs | 0.0526 μs |  33,577 B |      56 B |
|                                              |              |              |           |           |           |           |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX512F | 8KB          |     2.681 μs | 0.0021 μs | 0.0018 μs |  22,940 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed      | 8KB          |     2.708 μs | 0.0018 μs | 0.0017 μs |  31,039 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX2    | 8KB          |     3.146 μs | 0.0014 μs | 0.0013 μs |  22,079 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Ssse3   | 8KB          |     7.099 μs | 0.0022 μs | 0.0018 μs |  17,468 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native   | 8KB          |     7.384 μs | 0.0038 μs | 0.0036 μs |     970 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed  | 8KB          |     8.557 μs | 0.0151 μs | 0.0134 μs |  15,524 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar  | 8KB          |    13.811 μs | 0.0261 μs | 0.0231 μs |  25,683 B |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle        | 8KB          |   113.432 μs | 0.2217 μs | 0.1852 μs |  33,464 B |      56 B |
|                                              |              |              |           |           |           |           |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed      | 128KB        |    17.499 μs | 0.0093 μs | 0.0077 μs |  30,849 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX512F | 128KB        |    19.241 μs | 0.0212 μs | 0.0188 μs |  22,748 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX2    | 128KB        |    23.862 μs | 0.0364 μs | 0.0323 μs |  22,274 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Ssse3   | 128KB        |    89.951 μs | 0.0385 μs | 0.0321 μs |  17,473 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native   | 128KB        |    93.253 μs | 0.0534 μs | 0.0500 μs |     970 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed  | 128KB        |   102.568 μs | 0.1290 μs | 0.1143 μs |   9,772 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar  | 128KB        |   179.474 μs | 0.1276 μs | 0.0996 μs |  25,493 B |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle        | 128KB        | 1,504.722 μs | 1.7812 μs | 1.5790 μs |  27,306 B |      56 B |