| Description                                   | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|---------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 128B         |     1.187 μs | 0.0022 μs | 0.0018 μs |         - |
| Decrypt · Kuznyechik-CBC (Regional)           | 128B         |     8.636 μs | 0.0085 μs | 0.0075 μs |    1024 B |
|                                               |              |              |           |           |           |
| Encrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 128B         |     1.096 μs | 0.0026 μs | 0.0022 μs |         - |
| Encrypt · Kuznyechik-CBC (Regional)           | 128B         |     9.017 μs | 0.0190 μs | 0.0178 μs |     896 B |
|                                               |              |              |           |           |           |
| Decrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 1KB          |     8.414 μs | 0.0127 μs | 0.0118 μs |         - |
| Decrypt · Kuznyechik-CBC (Regional)           | 1KB          |    45.779 μs | 0.0547 μs | 0.0512 μs |    3712 B |
|                                               |              |              |           |           |           |
| Encrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 1KB          |     7.732 μs | 0.0121 μs | 0.0108 μs |         - |
| Encrypt · Kuznyechik-CBC (Regional)           | 1KB          |    48.624 μs | 0.0706 μs | 0.0590 μs |    2688 B |
|                                               |              |              |           |           |           |
| Decrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 8KB          |    66.309 μs | 0.1302 μs | 0.1087 μs |         - |
| Decrypt · Kuznyechik-CBC (Regional)           | 8KB          |   343.779 μs | 0.4107 μs | 0.3641 μs |   25216 B |
|                                               |              |              |           |           |           |
| Encrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 8KB          |    60.509 μs | 0.0505 μs | 0.0394 μs |         - |
| Encrypt · Kuznyechik-CBC (Regional)           | 8KB          |   366.012 μs | 0.4232 μs | 0.3752 μs |   17024 B |
|                                               |              |              |           |           |           |
| Decrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 128KB        | 1,056.863 μs | 1.2825 μs | 1.0709 μs |         - |
| Decrypt · Kuznyechik-CBC (Regional)           | 128KB        | 5,498.569 μs | 6.9705 μs | 6.5202 μs |  393895 B |
|                                               |              |              |           |           |           |
| Encrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 128KB        |   972.581 μs | 3.2113 μs | 2.8467 μs |         - |
| Encrypt · Kuznyechik-CBC (Regional)           | 128KB        | 5,825.349 μs | 5.4070 μs | 4.5151 μs |  262810 B |