| Description                                  | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|--------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| AbsorbSqueeze · BLAKE3 · CryptoHives-Ssse3   | 128B         |     1.660 μs | 0.0012 μs | 0.0012 μs |   8,429 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX2    | 128B         |     1.678 μs | 0.0009 μs | 0.0007 μs |  13,339 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX512F | 128B         |     1.682 μs | 0.0008 μs | 0.0007 μs |  13,339 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native   | 128B         |     1.753 μs | 0.0015 μs | 0.0014 μs |     976 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed      | 128B         |     1.826 μs | 0.0009 μs | 0.0007 μs |  20,319 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed  | 128B         |     2.417 μs | 0.0050 μs | 0.0045 μs |   6,857 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar  | 128B         |     2.841 μs | 0.0057 μs | 0.0047 μs |  16,637 B |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle        | 128B         |    22.787 μs | 0.0328 μs | 0.0291 μs |  28,667 B |      56 B |
|                                              |              |              |           |           |           |           |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX512F | 1KB          |     1.716 μs | 0.0033 μs | 0.0026 μs |  13,895 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX2    | 1KB          |     1.780 μs | 0.0151 μs | 0.0141 μs |  13,319 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed      | 1KB          |     1.887 μs | 0.0025 μs | 0.0022 μs |  20,473 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Ssse3   | 1KB          |     2.264 μs | 0.0015 μs | 0.0014 μs |   8,429 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native   | 1KB          |     2.379 μs | 0.0049 μs | 0.0041 μs |     976 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed  | 1KB          |     3.083 μs | 0.0107 μs | 0.0090 μs |   6,857 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar  | 1KB          |     4.126 μs | 0.0095 μs | 0.0079 μs |  16,637 B |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle        | 1KB          |    33.473 μs | 0.1193 μs | 0.1116 μs |  28,886 B |      56 B |
|                                              |              |              |           |           |           |           |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX512F | 8KB          |     2.684 μs | 0.0202 μs | 0.0189 μs |  13,895 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed      | 8KB          |     2.706 μs | 0.0018 μs | 0.0016 μs |  20,473 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX2    | 8KB          |     3.012 μs | 0.0056 μs | 0.0053 μs |  13,319 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Ssse3   | 8KB          |     7.097 μs | 0.0042 μs | 0.0035 μs |   8,429 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native   | 8KB          |     7.438 μs | 0.0532 μs | 0.0497 μs |     976 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed  | 8KB          |     8.618 μs | 0.0659 μs | 0.0617 μs |   6,857 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar  | 8KB          |    13.795 μs | 0.0719 μs | 0.0637 μs |  16,637 B |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle        | 8KB          |   117.765 μs | 0.1434 μs | 0.1120 μs |  28,638 B |      56 B |
|                                              |              |              |           |           |           |           |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed      | 128KB        |    17.216 μs | 0.0254 μs | 0.0237 μs |  20,473 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX512F | 128KB        |    19.351 μs | 0.1644 μs | 0.1538 μs |  13,895 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX2    | 128KB        |    23.990 μs | 0.0287 μs | 0.0254 μs |  13,319 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Ssse3   | 128KB        |    89.978 μs | 0.0382 μs | 0.0319 μs |   8,429 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native   | 128KB        |    93.270 μs | 0.1145 μs | 0.1071 μs |     976 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed  | 128KB        |   102.543 μs | 0.1495 μs | 0.1399 μs |   6,857 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar  | 128KB        |   179.534 μs | 0.5778 μs | 0.4825 μs |  16,637 B |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle        | 128KB        | 1,594.077 μs | 1.9617 μs | 1.6381 μs |  28,652 B |      56 B |