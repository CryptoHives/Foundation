| Description                                 | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|-------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native  | 128B         |   1.658 μs | 0.0050 μs | 0.0044 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 128B         |   1.704 μs | 0.0034 μs | 0.0032 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Neon   | 128B         |   1.711 μs | 0.0049 μs | 0.0046 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed     | 128B         |   1.712 μs | 0.0048 μs | 0.0045 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed | 128B         |   2.107 μs | 0.0041 μs | 0.0036 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 128B         |  12.318 μs | 0.0305 μs | 0.0285 μs |      56 B |
|                                             |              |            |           |           |           |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Neon   | 1KB          |   2.001 μs | 0.0081 μs | 0.0075 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed     | 1KB          |   2.012 μs | 0.0098 μs | 0.0092 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native  | 1KB          |   2.286 μs | 0.0126 μs | 0.0118 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 1KB          |   2.361 μs | 0.0033 μs | 0.0031 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed | 1KB          |   2.868 μs | 0.0101 μs | 0.0094 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 1KB          |  17.491 μs | 0.1107 μs | 0.1036 μs |      56 B |
|                                             |              |            |           |           |           |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed     | 8KB          |   4.703 μs | 0.0282 μs | 0.0263 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Neon   | 8KB          |   4.790 μs | 0.0226 μs | 0.0211 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native  | 8KB          |   7.335 μs | 0.0148 μs | 0.0139 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 8KB          |   7.656 μs | 0.0204 μs | 0.0191 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed | 8KB          |   8.929 μs | 0.0331 μs | 0.0293 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 8KB          |  56.289 μs | 0.1803 μs | 0.1687 μs |      56 B |
|                                             |              |            |           |           |           |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed     | 128KB        |  52.874 μs | 0.1219 μs | 0.1140 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Neon   | 128KB        |  53.914 μs | 0.1934 μs | 0.1809 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native  | 128KB        |  93.816 μs | 0.1994 μs | 0.1865 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 128KB        |  98.254 μs | 0.2708 μs | 0.2533 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed | 128KB        | 112.947 μs | 0.2268 μs | 0.2011 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 128KB        | 713.501 μs | 2.5996 μs | 2.4317 μs |      56 B |