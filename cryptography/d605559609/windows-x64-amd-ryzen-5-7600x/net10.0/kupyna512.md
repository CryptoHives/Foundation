| Description                                      | TestDataSize | Mean         | Error      | StdDev     | Median       | Code Size | Allocated |
|------------------------------------------------- |------------- |-------------:|-----------:|-----------:|-------------:|----------:|----------:|
| TryComputeHash · Kupyna-512 · CryptoHives-Scalar | 128B         |     4.192 μs |  0.0250 μs |  0.0234 μs |     4.191 μs |   7,083 B |         - |
| TryComputeHash · Kupyna-512 · BouncyCastle       | 128B         |     6.890 μs |  0.0420 μs |  0.0328 μs |     6.882 μs |   5,997 B |         - |
|                                                  |              |              |            |            |              |           |           |
| TryComputeHash · Kupyna-512 · CryptoHives-Scalar | 137B         |     4.226 μs |  0.0099 μs |  0.0088 μs |     4.227 μs |   7,092 B |         - |
| TryComputeHash · Kupyna-512 · BouncyCastle       | 137B         |     7.049 μs |  0.1292 μs |  0.2581 μs |     6.908 μs |   6,622 B |         - |
|                                                  |              |              |            |            |              |           |           |
| TryComputeHash · Kupyna-512 · CryptoHives-Scalar | 1KB          |    15.896 μs |  0.1067 μs |  0.0945 μs |    15.880 μs |   7,066 B |         - |
| TryComputeHash · Kupyna-512 · BouncyCastle       | 1KB          |    26.156 μs |  0.1711 μs |  0.1336 μs |    26.142 μs |   5,998 B |         - |
|                                                  |              |              |            |            |              |           |           |
| TryComputeHash · Kupyna-512 · CryptoHives-Scalar | 1025B        |    15.921 μs |  0.0999 μs |  0.0934 μs |    15.913 μs |   7,075 B |         - |
| TryComputeHash · Kupyna-512 · BouncyCastle       | 1025B        |    26.351 μs |  0.0908 μs |  0.0805 μs |    26.322 μs |   6,626 B |         - |
|                                                  |              |              |            |            |              |           |           |
| TryComputeHash · Kupyna-512 · CryptoHives-Scalar | 8KB          |   109.530 μs |  0.9695 μs |  0.8096 μs |   109.498 μs |   7,064 B |         - |
| TryComputeHash · Kupyna-512 · BouncyCastle       | 8KB          |   179.605 μs |  0.7592 μs |  0.7102 μs |   179.759 μs |   6,000 B |         - |
|                                                  |              |              |            |            |              |           |           |
| TryComputeHash · Kupyna-512 · CryptoHives-Scalar | 128KB        | 1,705.454 μs |  5.7032 μs |  5.0558 μs | 1,704.857 μs |   7,075 B |         - |
| TryComputeHash · Kupyna-512 · BouncyCastle       | 128KB        | 2,816.684 μs | 12.1152 μs | 10.1168 μs | 2,813.581 μs |   6,010 B |         - |