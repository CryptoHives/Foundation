| Description                                   | TestDataSize | Mean         | Error       | StdDev    | Code Size | Allocated |
|---------------------------------------------- |------------- |-------------:|------------:|----------:|----------:|----------:|
| ComputeMac · HMAC-SHA256 · OS                 | 128B         |     217.7 ns |     0.41 ns |   0.34 ns |   4,639 B |     320 B |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 128B         |     771.0 ns |     2.65 ns |   2.35 ns |   2,858 B |         - |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 128B         |   1,013.0 ns |     1.74 ns |   1.55 ns |   1,333 B |         - |
|                                               |              |              |             |           |           |           |
| ComputeMac · HMAC-SHA256 · OS                 | 137B         |     218.3 ns |     0.76 ns |   0.67 ns |   4,639 B |     336 B |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 137B         |     764.4 ns |     1.25 ns |   1.16 ns |   2,858 B |         - |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 137B         |   1,008.6 ns |     3.70 ns |   3.46 ns |   1,333 B |         - |
|                                               |              |              |             |           |           |           |
| ComputeMac · HMAC-SHA256 · OS                 | 1KB          |     572.5 ns |     2.34 ns |   2.07 ns |   4,643 B |    1216 B |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 1KB          |   3,236.5 ns |     6.42 ns |   5.37 ns |   1,333 B |         - |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 1KB          |   3,285.6 ns |     4.62 ns |   4.10 ns |   2,866 B |         - |
|                                               |              |              |             |           |           |           |
| ComputeMac · HMAC-SHA256 · OS                 | 1025B        |     574.5 ns |     3.49 ns |   2.92 ns |   4,643 B |    1224 B |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 1025B        |   3,254.8 ns |     3.87 ns |   3.23 ns |   1,333 B |         - |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 1025B        |   3,296.0 ns |     6.20 ns |   4.84 ns |   2,866 B |         - |
|                                               |              |              |             |           |           |           |
| ComputeMac · HMAC-SHA256 · OS                 | 8KB          |   3,684.3 ns |    23.60 ns |  18.43 ns |   4,576 B |    8384 B |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 8KB          |  21,027.1 ns |    35.55 ns |  31.52 ns |   1,333 B |         - |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 8KB          |  23,468.3 ns |    49.96 ns |  44.29 ns |   2,858 B |         - |
|                                               |              |              |             |           |           |           |
| ComputeMac · HMAC-SHA256 · OS                 | 128KB        |  86,467.8 ns |   415.43 ns | 346.90 ns |   4,576 B |  131278 B |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 128KB        | 326,208.5 ns | 1,027.34 ns | 857.88 ns |   1,333 B |         - |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 128KB        | 369,514.1 ns |   867.13 ns | 768.69 ns |   2,866 B |         - |