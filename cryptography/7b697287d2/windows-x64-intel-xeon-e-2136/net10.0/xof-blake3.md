| Description                                 | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|-------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| AbsorbSqueeze · BLAKE3 · CryptoHives-Ssse3  | 128B         |     1.640 μs | 0.0215 μs | 0.0201 μs |   7,932 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native  | 128B         |     1.708 μs | 0.0263 μs | 0.0246 μs |     979 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX2   | 128B         |     1.771 μs | 0.0284 μs | 0.0265 μs |  15,959 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed     | 128B         |     1.822 μs | 0.0240 μs | 0.0224 μs |  25,386 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed | 128B         |     2.395 μs | 0.0368 μs | 0.0344 μs |   7,007 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 128B         |     3.198 μs | 0.0409 μs | 0.0383 μs |  15,849 B |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 128B         |    18.139 μs | 0.3254 μs | 0.3044 μs |  28,848 B |      56 B |
|                                             |              |              |           |           |           |           |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX2   | 1KB          |     1.938 μs | 0.0206 μs | 0.0193 μs |  15,936 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed     | 1KB          |     1.981 μs | 0.0292 μs | 0.0273 μs |  25,160 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Ssse3  | 1KB          |     2.293 μs | 0.0369 μs | 0.0345 μs |   7,932 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native  | 1KB          |     2.388 μs | 0.0431 μs | 0.0403 μs |     979 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed | 1KB          |     3.166 μs | 0.0439 μs | 0.0411 μs |   7,007 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 1KB          |     4.475 μs | 0.0712 μs | 0.0666 μs |  15,849 B |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 1KB          |    25.734 μs | 0.3914 μs | 0.3661 μs |  29,066 B |      56 B |
|                                             |              |              |           |           |           |           |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed     | 8KB          |     4.538 μs | 0.0440 μs | 0.0367 μs |  25,160 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX2   | 8KB          |     4.858 μs | 0.0089 μs | 0.0079 μs |  15,938 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Ssse3  | 8KB          |     7.317 μs | 0.0126 μs | 0.0105 μs |   7,932 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native  | 8KB          |     7.593 μs | 0.0149 μs | 0.0139 μs |     979 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed | 8KB          |     9.258 μs | 0.0123 μs | 0.0109 μs |   7,007 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 8KB          |    14.211 μs | 0.0428 μs | 0.0379 μs |  15,849 B |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 8KB          |    82.301 μs | 0.3155 μs | 0.2951 μs |  28,825 B |      56 B |
|                                             |              |              |           |           |           |           |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed     | 128KB        |    49.226 μs | 0.3446 μs | 0.3224 μs |  25,138 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX2   | 128KB        |    54.162 μs | 0.5244 μs | 0.4906 μs |  15,936 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Ssse3  | 128KB        |    97.108 μs | 0.9747 μs | 0.9117 μs |   7,932 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native  | 128KB        |   101.382 μs | 0.9918 μs | 0.9278 μs |     979 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed | 128KB        |   117.012 μs | 0.5526 μs | 0.5169 μs |   7,007 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 128KB        |   188.493 μs | 1.9024 μs | 1.7795 μs |  15,849 B |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 128KB        | 1,110.976 μs | 5.2280 μs | 4.8903 μs |  28,839 B |      56 B |