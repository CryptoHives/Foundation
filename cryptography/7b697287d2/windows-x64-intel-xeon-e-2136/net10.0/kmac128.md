| Description                                    | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|----------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|----------:|
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 128B         |   1.356 μs | 0.0014 μs | 0.0012 μs |   8,401 B |         - |
| TryComputeHash · KMAC-128 · OS Native          | 128B         |   2.331 μs | 0.0058 μs | 0.0055 μs |   7,281 B |     184 B |
| TryComputeHash · KMAC-128 · BouncyCastle       | 128B         |   3.676 μs | 0.0041 μs | 0.0036 μs |  16,752 B |     256 B |
|                                                |              |            |           |           |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 137B         |   1.354 μs | 0.0012 μs | 0.0010 μs |   8,412 B |         - |
| TryComputeHash · KMAC-128 · OS Native          | 137B         |   2.351 μs | 0.0041 μs | 0.0039 μs |   7,557 B |     200 B |
| TryComputeHash · KMAC-128 · BouncyCastle       | 137B         |   3.668 μs | 0.0053 μs | 0.0049 μs |  16,765 B |     256 B |
|                                                |              |            |           |           |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 1KB          |   3.848 μs | 0.0034 μs | 0.0032 μs |   8,390 B |         - |
| TryComputeHash · KMAC-128 · OS Native          | 1KB          |   5.853 μs | 0.0208 μs | 0.0195 μs |   7,557 B |    1080 B |
| TryComputeHash · KMAC-128 · BouncyCastle       | 1KB          |   6.988 μs | 0.0104 μs | 0.0097 μs |  16,820 B |     256 B |
|                                                |              |            |           |           |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 1025B        |   3.834 μs | 0.0067 μs | 0.0060 μs |   8,390 B |         - |
| TryComputeHash · KMAC-128 · OS Native          | 1025B        |   5.842 μs | 0.0123 μs | 0.0109 μs |   7,555 B |    1088 B |
| TryComputeHash · KMAC-128 · BouncyCastle       | 1025B        |   6.976 μs | 0.0083 μs | 0.0078 μs |  16,797 B |     256 B |
|                                                |              |            |           |           |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 8KB          |  20.885 μs | 0.0275 μs | 0.0244 μs |   8,400 B |         - |
| TryComputeHash · KMAC-128 · BouncyCastle       | 8KB          |  30.785 μs | 0.0594 μs | 0.0527 μs |  21,322 B |     256 B |
| TryComputeHash · KMAC-128 · OS Native          | 8KB          |  31.114 μs | 0.0564 μs | 0.0528 μs |   7,467 B |    8248 B |
|                                                |              |            |           |           |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 128KB        | 317.747 μs | 0.6122 μs | 0.5727 μs |   8,388 B |         - |
| TryComputeHash · KMAC-128 · BouncyCastle       | 128KB        | 443.957 μs | 0.3632 μs | 0.3219 μs |  21,452 B |     256 B |
| TryComputeHash · KMAC-128 · OS Native          | 128KB        | 521.103 μs | 0.5697 μs | 0.5329 μs |   7,829 B |  131151 B |